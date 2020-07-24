import { signUp } from '@/services/user'
import { PageHeaderWrapper } from '@ant-design/pro-layout'
import { Button, Card, Form, Input, message, Select, Space } from 'antd'
import React from 'react'
import { useMutation } from 'react-query'
import { accountTypes } from '../Account/ViewAll'
import styles from './index.less'
const { Option } = Select

const layout = {
  labelCol: { span: 8 },
  wrapperCol: { span: 16 },
}
const tailLayout = {
  wrapperCol: { offset: 8, span: 16 },
}

export default () => {
  const [muSignUp] = useMutation(signUp, {
    onError(e) {
      message.warn(e.message || e)
    },
    onSuccess() {
      message.success('Add account success')
    },
  })

  const onFinish = (values: any) => {
    muSignUp(values)
  }

  return (
    <PageHeaderWrapper content="Add account" className={styles.main}>
      <Form {...layout} name="basic" initialValues={{ remember: true }} onFinish={onFinish}>
        <Space direction="vertical" className="w-full">
          <Card>
            <Form.Item
              label="Email"
              name="email"
              rules={[
                { required: true, message: 'Please input your email!' },
                {
                  type: 'email',
                  message: 'Not an email format',
                },
              ]}
            >
              <Input />
            </Form.Item>
            <Form.Item label="Name" name="name" rules={[{ required: true, message: 'name' }]}>
              <Input />
            </Form.Item>

            <Form.Item
              label="Password"
              name="password"
              rules={[{ required: true, message: 'Please input your password!' }]}
            >
              <Input.Password />
            </Form.Item>

            <Form.Item name="type" label="Type" initialValue={0}>
              <Select defaultValue={0} style={{ width: 220 }}>
                {accountTypes.map((v, i) => {
                  return <Option value={i}>{v}</Option>
                })}
              </Select>
            </Form.Item>

            <Form.Item {...tailLayout}>
              <Button type="primary" htmlType="submit">
                Submit
              </Button>
            </Form.Item>
          </Card>
        </Space>
      </Form>
    </PageHeaderWrapper>
  )
}
