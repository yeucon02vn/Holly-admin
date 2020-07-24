import { Modal, Select } from 'antd'
import React from 'react'

const { Option } = Select

interface ModalChangeStatusProduct {
  id: string
  handleOk: (id: string, value: number) => void
  handleCancel: () => void
  show: boolean
}

export const StatusProduct = {
  active: 1,
  unactive: 0,
}

export const ModalChangeStatusProduct: React.FC<ModalChangeStatusProduct> = (props) => {
  const { id, handleCancel, handleOk, show } = props
  const [value, setValue] = React.useState(0)

  const handleChange = (v: number) => {
    setValue(v)
  }

  return (
    <div>
      <div id="components-modal-demo-basic">
        <Modal
          title="Change product status"
          visible={show}
          onOk={() => handleOk(id, value)}
          onCancel={handleCancel}
        >
          <Select defaultValue={1} style={{ width: 220 }} onChange={handleChange}>
            <Option value={StatusProduct.unactive}>Unactive</Option>
            <Option value={StatusProduct.active}>Active</Option>
          </Select>
        </Modal>
      </div>
    </div>
  )
}
