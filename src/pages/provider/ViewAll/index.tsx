import { useQueryGetProviders } from '@/services/provider'
import { PageHeaderWrapper } from '@ant-design/pro-layout'
import { Card, Table } from 'antd'
import React from 'react'
import styles from './index.less'
const { Column } = Table

export default () => {
  const { data, isFetching } = useQueryGetProviders()
  return (
    <PageHeaderWrapper content="Provider:" className={styles.main}>
      <Card>
        <Table className="mb-8" loading={isFetching} dataSource={data || []}>
          <Column title="Id" dataIndex="id" key="id" />
          <Column title="Name" dataIndex="name" key="name" />
          <Column title="Description" dataIndex="description" key="receiverAdderss" />
        </Table>
      </Card>
    </PageHeaderWrapper>
  )
}
