import { updateStock, useGetQuantityByProductId } from '@/services/warehouse'
import { Button, Input, message, Modal, Space } from 'antd'
import React, { useRef } from 'react'
import { queryCache, useMutation } from 'react-query'

interface ModalAddStockProduct {
  id: string
  handleOk: (id: string, value: number) => void
  handleCancel: () => void
  show: boolean
  currentStock: number
}

export const StatusProduct = {
  active: 1,
  unactive: 0,
}

export const ModalAddStock: React.FC<ModalAddStockProduct> = (props) => {
  const { id, handleCancel, show } = props
  const [value, setValue] = React.useState(0)

  const { data, isLoading } = useGetQuantityByProductId(id)
  const [muUpdate] = useMutation(updateStock, {
    onError(e) {
      message.warning(e.message)
    },
    onSuccess(d) {
      message.success('Update success')
      queryCache.invalidateQueries('getProducts')
      queryCache.invalidateQueries('useGetQuantityByProductId')
    },
  })

  const refAdd = useRef<any>(null)
  const refUpdate = useRef<any>(null)
  const refDelete = useRef<any>(null)

  if (isLoading) return null

  const currentStock = Number(data) || 0

  const handleChangetock = (type: string) => {
    let value = 0
    console.log('refAdd?.current.value', refAdd?.current?.state?.value)
    if (type === 'add') {
      value = Number(refAdd?.current?.state?.value) + currentStock
    } else if (type === 'delete') {
      value = currentStock - Number(refDelete?.current?.state?.value)
    } else {
      value = Number(refUpdate?.current?.state?.value)
    }
    muUpdate({
      productId: id,
      quantity: value,
    })
  }

  return (
    <div>
      <div id="components-modal-demo-basic">
        <Modal
          title="Change stock"
          visible={show}
          onCancel={handleCancel}
          footer={[
            <Button key="back" onClick={handleCancel}>
              Return
            </Button>,
          ]}
        >
          <Space className="flex-col p-4 px-8">
            <Space className="flex mb-12">
              <p>Current stock:</p>
              <p className="text-indigo-500">{currentStock}</p>
            </Space>
            <Space className="flex mb-8">
              <p>Add stock: </p>
              <Input ref={refAdd} placeholder="Input number" />
              <Button onClick={() => handleChangetock('add')}> Add stock</Button>
            </Space>
            <Space className="flex mb-8">
              <p>Delete stock: </p>
              <Input ref={refDelete} placeholder="Input number" />
              <Button onClick={() => handleChangetock('delete')}> Delete stock</Button>
            </Space>

            <Space className="flex mb-8">
              <p>Update: </p>
              <Input ref={refUpdate} placeholder="Input number" />
              <Button onClick={() => handleChangetock('update')}> Update</Button>
            </Space>
          </Space>
        </Modal>
      </div>
    </div>
  )
}
