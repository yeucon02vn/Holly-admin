import { feedbackUrls, getFeedbacksWithCustomUrl, markReadFeedback } from '@/services/feedback'
import { PageHeaderWrapper } from '@ant-design/pro-layout'
import { Card, Space, Table, Tag, message } from 'antd'
import Column from 'antd/lib/table/Column'
import moment from 'moment'
import React, { useState } from 'react'
import { usePaginatedQuery, useMutation, queryCache } from 'react-query'
import { PresetColorType } from 'antd/es/_util/colors'

export default () => {
  const [page, setPage] = useState<number>(1)
  const [query, setQuery] = useState(feedbackUrls.getAll)
  const { resolvedData, latestData, isFetching } = usePaginatedQuery(
    ['getFeedbacks', query, page],
    getFeedbacksWithCustomUrl,
    {},
  )

  const [muSeenFeedback] = useMutation(markReadFeedback, {
    onSuccess() {
      message.success('Update success')
      queryCache.invalidateQueries('getFeedbacks')
    },
    onError(e) {
      message.error(e.message)
    },
  })

  const handleTableChange = (pagination: any) => {
    setPage(pagination?.current)
  }

  const pagination = {
    current: page,
    pageSize: 10,
    total: latestData?.pagination?.totalCount,
  }

  /* ------------- renders ------------- */

  const renderActions = (v: API.Feedback) => {
    return (
      <Space>
        <p
          className="text-blue-400 cursor-pointer"
          onClick={() => {
            muSeenFeedback({
              id: v.id,
              isRead: true,
            })
          }}
        >
          Mark as read
        </p>
        <p
          className="text-green-400 cursor-pointer"
          onClick={() => {
            muSeenFeedback({
              id: v.id,
              isRead: false,
            })
          }}
        >
          Mark as unread
        </p>
      </Space>
    )
  }

  const renderStatus = (isRead: boolean) => {
    const v = isRead ? 'Read' : 'Unread'
    const color: PresetColorType = isRead ? 'blue' : 'green'
    return (
      <Tag color={color} key={v}>
        {v}
      </Tag>
    )
  }

  return (
    <PageHeaderWrapper content="Feedbacks">
      <Space direction="vertical" size="large" className="w-full">
        <Card>
          <Table
            className="mb-8"
            loading={isFetching}
            dataSource={resolvedData?.items}
            pagination={pagination}
            onChange={handleTableChange}
          >
            <Column title="Id" dataIndex="id" key="id11" />
            <Column title="Email" dataIndex="email" key="productName" />
            <Column title="Title" dataIndex="title" key="provider" />
            <Column title="Description" dataIndex="description" key="quantityInStock" />
            <Column title="Order id" dataIndex="orderId" key="quantityInStock" />
            <Column title="Status" dataIndex="isRead" render={renderStatus} />
            <Column
              title="Date"
              dataIndex="createdDate"
              render={(v) => <p>{moment(v).format('DD/MM/YYYY')}</p>}
            />
            <Column title="Action" render={renderActions} />
          </Table>
        </Card>
      </Space>
    </PageHeaderWrapper>
  )
}
