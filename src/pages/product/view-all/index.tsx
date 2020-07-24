import { CLIENT_URL } from '@/services/api-config'
import { changeProductStatus, getProductsWithCustomUrl, productsUrl } from '@/services/product'
import { formatMoney } from '@/utils/strings'
import { PageHeaderWrapper } from '@ant-design/pro-layout'
import { Card, Input, notification, Space, Spin, Table, Tag } from 'antd'
import React, { useState } from 'react'
import { queryCache, usePaginatedQuery } from 'react-query'
import { ModalChangeStatusProduct } from './ModalChangeStatusProduct'
import { ModalAddStock } from './ModalAddStock'
const { Column } = Table

const MODAL_STATUS = 0
const MODAL_ADD_STOCK = 1

export default () => {
  // const { data, isLoading } = useGetProducts()
  const [page, setPage] = useState<number>(1)
  const [query, setQuery] = useState(productsUrl.getProducts)

  const [currentId, setCurrentId] = useState('')
  const [currentStock, setCurrentStock] = useState(0)
  const [showModal, setShowModal] = useState(-1)

  const { resolvedData, latestData, isFetching } = usePaginatedQuery(
    ['getProducts', query, page],
    getProductsWithCustomUrl,
    {},
  )

  /* ------------- methods ------------- */
  const handleTableChange = (pagination: any) => {
    setPage(pagination?.current)
  }

  const handleModalOk = (id: string, value: number) => {
    changeProductStatus(id, value)
      .then(() => {
        notification.success({
          message: 'Success',
        })
        queryCache.invalidateQueries('getProducts')
      })
      .catch((e) => {
        notification.warning({ message: 'Error ', description: JSON.stringify(e) })
      })
  }

  const handleCancelModal = () => {
    setShowModal(-1)
    setCurrentId('')
  }

  const pagination = {
    current: page,
    pageSize: 10,
    total: latestData?.pagination?.totalCount,
  }

  /* ------------- renders ------------- */
  const renderAction = (id: string) => {
    return (
      <Space size="middle">
        <a
          onClick={() => {
            const url = `${CLIENT_URL}/product/${id}`
            window.location.replace(url)
          }}
          className=""
        >
          Edit
        </a>

        <p
          className="text-blue-400 cursor-pointer"
          onClick={() => {
            setCurrentId(id)
            setShowModal(MODAL_STATUS)
          }}
        >
          Change status
        </p>
        <p
          className="text-blue-400 cursor-pointer"
          onClick={() => {
            setCurrentId(id)
            setShowModal(MODAL_ADD_STOCK)
            const curentItem = resolvedData?.items.filter((v) => v.id === id)
            if (curentItem && curentItem[0]) setCurrentStock(curentItem[0].quantityInStock)
          }}
        >
          Add stock
        </p>
      </Space>
    )
  }

  const renderDeleteCol = (isDeleted: boolean) => {
    const tx = isDeleted ? 'Unactive' : 'Active'
    const color = isDeleted ? 'warning' : 'success'
    return (
      <Tag color={color} key={tx}>
        {tx}
      </Tag>
    )
  }

  const renderLoading = () => <Spin />

  const renderPage = () => {
    return (
      <Space direction="vertical" size="large" className="w-full">
        <Table
          className="mb-8"
          loading={isFetching}
          dataSource={resolvedData?.items}
          pagination={pagination}
          onChange={handleTableChange}
        >
          <Column title="Id" dataIndex="id" key="id11" />
          <Column title="Product name" dataIndex="productName" key="productName" />
          <Column title="Provider" dataIndex="provider" key="provider" />
          <Column title="Quantity" dataIndex="quantityInStock" key="quantityInStock" />
          <Column
            title="Price"
            dataIndex="price"
            key="price"
            render={(v) => <p>{formatMoney(v)}</p>}
          />
          <Column title="Status" dataIndex="isDeleted" key="isDeleted" render={renderDeleteCol} />
          <Column title="Action" dataIndex="id" key="action" render={renderAction} />
        </Table>
      </Space>
    )
  }
  return (
    <PageHeaderWrapper>
      <Space direction="vertical" className="w-full">
        <Card>
          <Input.Search
            size="large"
            placeholder="input here"
            enterButton
            loading={isFetching}
            onSearch={(e) => {
              if (e !== '') setQuery(`${productsUrl.searchProduct}/${e}`)
              else setQuery(`${productsUrl.getProducts}`)
            }}
          />
        </Card>
        <Card bordered={false}>{isFetching ? renderLoading() : renderPage()}</Card>
      </Space>
      <ModalChangeStatusProduct
        id={currentId}
        show={showModal === MODAL_STATUS}
        handleOk={handleModalOk}
        handleCancel={handleCancelModal}
      />
      <ModalAddStock
        id={currentId}
        show={showModal === MODAL_ADD_STOCK}
        handleOk={handleModalOk}
        handleCancel={handleCancelModal}
        currentStock={currentStock}
      />
    </PageHeaderWrapper>
  )
}
