import { mutDeleteUser, useQueryGetAllUser, changeAccountType } from '@/services/user'
import { PageHeaderWrapper } from '@ant-design/pro-layout'
import { Card, message, Space, Table, Tag, Input } from 'antd'
import React, { useState, useMemo, useCallback } from 'react'
import { useMutation, queryCache } from 'react-query'
import styles from './style.less'
import { ModalChangeInfo } from './ModalChangeInfo'
import { LiteralUnion } from 'antd/es/_util/type'
import { PresetColorType, PresetStatusColorType } from 'antd/es/_util/colors'

export const accountTypes = ['Admin', 'User', 'Employee']
const colors: PresetColorType[] = ['blue', 'green', 'gold']

const { Column } = Table

const ViewAll = () => {
  const { data, isFetching } = useQueryGetAllUser()
  const refresh = useCallback(() => {
    queryCache.invalidateQueries('getAllUser')
  }, [useQueryGetAllUser])
  const [deleteUser] = useMutation(mutDeleteUser, {
    onError(e) {
      message.error(e.message)
    },
    onSuccess(e) {
      message.success(`Delete success ${e?.id}`)
      refresh()
    },
  })
  const [updateAccount] = useMutation(changeAccountType, {
    onError(e) {
      message.error(e.message)
    },
    onSuccess(e) {
      message.success(`Update success ${e?.id}`)
      refresh()
    },
  })

  const [currentId, setCurrentId] = useState('')
  const [showModal, setShowModal] = React.useState(false)

  /* ------------- methods ------------- */
  const handleChange = (id: string, value: number) => {
    updateAccount({ id, type: value })
  }
  const handleCancelModalChangeInfo = () => {
    setShowModal(false)
    setCurrentId('')
  }

  /* ------------- renders ------------- */
  const renderAccountType = (type: number) => {
    return (
      <Tag color={colors[type]} key={accountTypes[type]}>
        {accountTypes[type]}
      </Tag>
    )
  }

  const renderAction = (id: string) => {
    return (
      <Space size="middle">
        <a
          onClick={() => {
            setCurrentId(id)
            setShowModal(true)
          }}
          className=""
        >
          Edit
        </a>
        <a className="text-blue-500" onClick={() => deleteUser(id)}>
          Delete
        </a>
      </Space>
    )
  }

  const renderIsDeleted = (isDeleted: boolean) => {
    if (isDeleted) {
      return (
        <Tag color="error" key="Deleted">
          Deleted
        </Tag>
      )
    }
    return (
      <Tag color="success" key="Available">
        Available
      </Tag>
    )
  }

  return (
    <PageHeaderWrapper>
      <Card bordered={false}>
        <div className={styles.title}>All account</div>
        <Table className="mb-8" loading={isFetching} dataSource={data}>
          <Column title="Id" dataIndex="id" key="id11" />
          <Column title="Name" dataIndex="name" key="name" />
          <Column title="Email" dataIndex="email" key="email" />
          <Column
            title="Account type"
            dataIndex="accountType"
            key="accountType"
            render={renderAccountType}
          />
          <Column title="Action" dataIndex="id" key="action" render={renderAction} />
          <Column title="status" dataIndex="isDeleted" key="status" render={renderIsDeleted} />
        </Table>
        <ModalChangeInfo
          id={currentId}
          show={showModal}
          handleOk={handleChange}
          handleCancel={handleCancelModalChangeInfo}
        />
      </Card>
    </PageHeaderWrapper>
  )
}

export default ViewAll
