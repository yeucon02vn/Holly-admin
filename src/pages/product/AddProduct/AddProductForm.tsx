import { createProduct } from '@/services/product'
import { useQueryGetProviders } from '@/services/provider'
import { Alert, AutoComplete, Button, Form, Input, notification } from 'antd'
import _ from 'lodash'
import React, { useRef, useState } from 'react'
import { useMutation } from 'react-query'
import { EditableTagGroup } from './ProductTags'

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

interface AddProductFormProps {}

export const AddProductForm: React.FC<AddProductFormProps> = (props) => {
  const [form] = Form.useForm()
  const [thumbnailImage, setThumbnailImg] = useState<any>(null)
  const [galleries, setGallaries] = useState<any>(null)
  const [providerOptions, setProviderOptions] = useState<{ value: string }[]>([])
  const { data: providersRaw } = useQueryGetProviders()
  const providers = providersRaw?.map((v) => ({
    value: v.name,
  }))
  // const onSearchProvider = (searchText: string) => {
  // setProviderOptions(
  // !searchText ? [] : [providers(searchText), mockVal(searchText, 2), mockVal(searchText, 3)],
  // );
  // };
  const refTags = useRef<any>({})
  const [muCreateProduct, { data }] = useMutation(createProduct, {
    onSuccess(d) {
      notification.success({
        message: 'Success',
        description: 'Insert product successfully',
      })
    },
    onError(e) {
      notification.error({
        message: e.message,
      })
    },
  })

  const onFinish = async (values: any) => {
    const formData = new FormData()
    if (thumbnailImage) formData.append('ThumbnailImg', thumbnailImage)
    galleries?.forEach((v: any) => {
      formData.append(`files`, v)
    })
    const descriptions = values.description.split('\n')

    if (thumbnailImage)
      muCreateProduct({
        input: {
          Provider: values.provider,
          Price: values.price,
          ProductName: values.productName,
          Info: {
            tagName: refTags.current.getValue(),
            descriptions,
          },
          quantity: Number(values?.quantity) > 0 ? Number(values?.quantity) : 0,
        },
        formData,
      })
  }

  const handleThumbnailChange = (e: any) => {
    setThumbnailImg(e.target.files[0])
  }

  const handleGallariesChange = (e: any) => {
    const arr: any = []
    _.forEach(e.target.files, (v) => {
      arr.push(v)
    })
    setGallaries(arr)
    // setThumbnailImg(e.target.files[0])
    // e.target?.files?.map((v, i) => {
    // console.log('v,i', v, i)
    // })
  }

  const rsData: any = data

  return (
    <>
      {rsData && rsData?.id && (
        <>
          <Alert message={`Created product with id: ${rsData?.id}`} type="success" />
          <div className="py-8" />
        </>
      )}

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
        <Form.Item
          name="productName"
          label="Product name"
          rules={[
            {
              required: true,
              message: 'Please input your Product name!',
            },
          ]}
        >
          <Input />
        </Form.Item>

        <Form.Item
          name="provider"
          label="Provider"
          rules={[
            {
              required: true,
              message: 'Please input your provider!',
            },
          ]}
          hasFeedback
        >
          <AutoComplete options={providers} style={{ width: 200 }} placeholder="input here" />
        </Form.Item>

        <Form.Item
          name="price"
          label="Price"
          rules={[
            {
              required: true,
              message: 'Please input product price !',
            },
            () => ({
              validator(rule, value) {
                if (Number(value)) {
                  return Promise.resolve()
                }
                return Promise.reject(new Error('Price should be number'))
              },
            }),
          ]}
        >
          <Input defaultValue={0} />
        </Form.Item>

        <Form.Item
          name="quantity"
          label="Initial quantity:"
          rules={[
            {
              required: true,
              message: 'Please input product quantity!',
            },
            () => ({
              validator(rule, value) {
                if (Number(value)) {
                  return Promise.resolve()
                }
                return Promise.reject(new Error('Price should be number'))
              },
            }),
          ]}
        >
          <Input defaultValue={0} />
        </Form.Item>

        <Form.Item
          name="description"
          label="Description"
          rules={[
            {
              required: true,
              message: 'Please input product description!',
            },
          ]}
        >
          <Input.TextArea />
        </Form.Item>

        <Form.Item name="thumbnailImage" label="Thumbnail">
          <Input type="file" onChange={handleThumbnailChange} accept="image/*" />
        </Form.Item>
        <Form.Item name="galleries" label="Galleries">
          <Input type="file" onChange={handleGallariesChange} multiple accept="image/*" />
        </Form.Item>

        <Form.Item name="tags" label="Tags">
          <EditableTagGroup ref={refTags} />
        </Form.Item>

        <Form.Item {...tailFormItemLayout}>
          <Button type="primary" htmlType="submit">
            Register
          </Button>
        </Form.Item>
      </Form>
    </>
  )
}
