import { searchProducts } from '@/services/product'
import { PageHeaderWrapper } from '@ant-design/pro-layout'
import { Form, Input, Spin } from 'antd'
import React from 'react'
import { useQuery, queryCache } from 'react-query'
import styles from './index.less'

const formItemLayout = {
  labelCol: {
    xs: { span: 24 },
    sm: { span: 8 },
  },
  wrapperCol: {
    xs: { span: 24 },
    sm: { span: 16 },
  },
}
const tailFormItemLayout = {
  wrapperCol: {
    xs: {
      span: 24,
      offset: 0,
    },
    sm: {
      span: 16,
      offset: 8,
    },
  },
}

export default () => {
  const [form] = Form.useForm()
  const [query, setQuery] = React.useState('')
  const { data, isFetching } = useQuery(['searchProducts', query], searchProducts, {
    enabled: !!query,
  })

  const onFinish = (values) => {}

  if (isFetching)
    return (
      <PageHeaderWrapper>
        <Spin />
      </PageHeaderWrapper>
    )

  return (
    <PageHeaderWrapper content="Update ware house" className={styles.main}>
      <div style={{ textAlign: 'center' }}>
        <Form
          {...formItemLayout}
          form={form}
          name="register"
          onFinish={onFinish}
          initialValues={{
            residence: ['zhejiang', 'hangzhou', 'xihu'],
            prefix: '86',
          }}
          scrollToFirstError
        >
          <Form.Item>
            <Input.Search
              placeholder="input id here"
              enterButton
              onSearch={(e) => {
                setQuery(e)
                queryCache.invalidateQueries('searchProducts')
              }}
            />
          </Form.Item>
        </Form>
      </div>
    </PageHeaderWrapper>
  )
}
