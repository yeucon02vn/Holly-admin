import { getOrderWithUrl as getOrdersWithUrl, orderUrls, updateOrderStatus } from '@/services/order'
import { PageHeaderWrapper } from '@ant-design/pro-layout'
import { Card, Input, notification, Table, Tag } from 'antd'
import { PresetColorType, PresetStatusColorType } from 'antd/es/_util/colors'
import { LiteralUnion } from 'antd/es/_util/type'
import moment from 'moment'
import React, { useMemo } from 'react'
import { queryCache, useMutation, useQuery } from 'react-query'
import { CANCEL, ModalUpdateStatus, TRANSPORTING, UNCONFIRMED } from './UpdateStatusModal'
const { Column } = Table

export interface Order {
  id: string
  carts: Cart[]
  note: string
  receiverAdderss: string
  orderDate: Date
  name: string
  phone: string
  cashType: string
  status: string
}

export interface Cart {
  productId: string
  amount: number
  name: string
  provider: string
  price: number
}

export default () => {
  /* ------------- mutations and query ------------- */
  const [url, setUrl] = React.useState(orderUrls.getAll)
  const { data, isFetching } = useQuery(['getAllOrders', url], getOrdersWithUrl)
  const [muUpdate] = useMutation(updateOrderStatus, {
    onSuccess() {
      notification.success({
        message: 'Update success',
      })
      queryCache.invalidateQueries('getAllOrders')
    },
    onError(e) {
      notification.warning({
        message: 'Error',
        description: e.message,
      })
    },
  })

  /* ------------- state------------- */
  const [currentId, setcurrentId] = React.useState('')
  const [showModal, setshowModal] = React.useState(false)
  const [statusValue, setstatusValue] = React.useState('')

  const orders = useMemo(
    () =>
      data
        ?.map((v) => ({
          id: v.id,
          ...v.orderinfo,
        }))
        .sort((a: any, b: any) => {
          const c = new Date(a?.orderDate)
          const d = new Date(b?.orderDate)
          return d.getTime() - c.getTime()
        })
        .sort((a: any) => {
          if (a?.status === UNCONFIRMED) return -1
          return 1
        }),
    [data],
  )

  /* ------------- methods ------------- */
  const handleCancelModalStatus = () => {
    setcurrentId('')
    setshowModal(false)
  }

  const handleOkModalStatus = (id: string, v: string) => {
    muUpdate({ id, status: v })
  }

  /* ------------- renders ------------- */
  const renderStatus = (v: string) => {
    let color: LiteralUnion<PresetColorType | PresetStatusColorType, string> = 'success'
    if (v === UNCONFIRMED) color = 'default'
    else if (v === TRANSPORTING) color = 'cyan'
    else if (v === CANCEL) color = 'warning'

    return (
      <Tag color={color} key={v}>
        {v}
      </Tag>
    )
  }

  const renderAction = (v: Order) => {
    return (
      <p
        className="text-blue-500 cursor-pointer"
        onClick={() => {
          setcurrentId(v.id)
          setstatusValue(v.status)
          setshowModal(true)
        }}
      >
        Update status
      </p>
    )
  }

  return (
    <PageHeaderWrapper content="View order">
      <Card>
        <Input.Search
          size="large"
          placeholder="input here"
          enterButton
          loading={isFetching}
          onSearch={(e) => {
            if (e !== '') setUrl(`${orderUrls.search}?input=${e}`)
            else setUrl(`${orderUrls.getAll}`)
          }}
        />

        <Table className="mb-8" loading={isFetching} dataSource={orders}>
          <Column title="Id" dataIndex="id" key="id" />
          <Column title="Name" dataIndex="name" key="name" />
          <Column title="Phone" dataIndex="phone" key="phone" />
          <Column title="Receiver addresss" dataIndex="receiverAdderss" key="receiverAdderss" />
          <Column
            title="Order date"
            dataIndex="orderDate"
            key="date"
            render={(v) => <p>{moment(v).format('DD/MM/YYYY')}</p>}
          />
          <Column key="status" title="status" render={renderStatus} dataIndex="status" />
          <Column key="action" title="Action" render={renderAction} />
        </Table>
      </Card>
      <ModalUpdateStatus
        id={currentId}
        show={showModal}
        handleOk={handleOkModalStatus}
        handleCancel={handleCancelModalStatus}
        defaultValue={statusValue}
      />
    </PageHeaderWrapper>
  )
}
