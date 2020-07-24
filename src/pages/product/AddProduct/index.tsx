import { PageHeaderWrapper } from '@ant-design/pro-layout'
import { Card } from 'antd'
import React from 'react'
import { AddProductForm } from './AddProductForm'
import styles from './index.less'

export default () => {
  return (
    <PageHeaderWrapper content="Add new product" className={styles.main}>
      <Card>
        <AddProductForm />
      </Card>
    </PageHeaderWrapper>
  )
}
