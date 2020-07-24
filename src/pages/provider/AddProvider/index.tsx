import { PageHeaderWrapper } from '@ant-design/pro-layout'
import { Button, Card, Checkbox, Form, Input, Space, message } from 'antd'
import React from 'react'
import styles from './index.less'
import { useMutation } from 'react-query'
import { createProvider } from '@/services/provider'

const layout = {
  labelCol: { span: 8 },
  wrapperCol: { span: 16 },
}
const tailLayout = {
  wrapperCol: { offset: 8, span: 16 },
}

export default () => {
  const [muCreateProvider] = useMutation(createProvider, {
    onSuccess() {
      message.success('Add provider success')
    },
    onError(e) {
      message.error(e.message || e)
    },
  })
  return (
    <PageHeaderWrapper content="Add provider" className={styles.main}>
      <Space direction="vertical" className="w-full">
        <Card>
          <Form
            {...layout}
            onFinish={(d: any) => {
              muCreateProvider(d)
            }}
          >
            <Form.Item
              label="Name"
              name="name"
              rules={[{ required: true, message: 'Please input provider name!' }]}
            >
              <Input />
            </Form.Item>

            <Form.Item
              label="Description"
              name="description"
              rules={[{ required: true, message: 'Please input provider description!' }]}
            >
              <Input />
            </Form.Item>

            <Form.Item {...tailLayout}>
              <Button type="primary" htmlType="submit">
                Submit
              </Button>
            </Form.Item>
          </Form>
        </Card>
      </Space>
    </PageHeaderWrapper>
  )
}
