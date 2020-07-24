import { Modal, Select } from 'antd'
import React from 'react'

const { Option } = Select

interface ModalUpdateStatusProps {
  id: string
  handleOk: (id: string, value: string) => void
  handleCancel: () => void
  show: boolean
  defaultValue?: string
}

export const UNCONFIRMED = 'Unconfimred'
export const TRANSPORTING = 'Transporting'
export const SUCCESS = 'Success'
export const CANCEL = 'Cancel'

const TransferStatus: string[] = [UNCONFIRMED, TRANSPORTING, SUCCESS, CANCEL]

export const ModalUpdateStatus: React.FC<ModalUpdateStatusProps> = (props) => {
  const { id, handleCancel, handleOk, show, defaultValue } = props
  const [value, setValue] = React.useState('')

  const handleChange = (v: string) => {
    setValue(v)
  }

  return (
    <div>
      <div id="components-modal-demo-basic">
        <Modal
          title="Change status"
          visible={show}
          onOk={() => handleOk(id, value)}
          onCancel={handleCancel}
        >
          <p className="my-4">Order id: {id}</p>
          <Select
            defaultValue={defaultValue || UNCONFIRMED}
            style={{ width: 220 }}
            onChange={handleChange}
          >
            {TransferStatus.map((v) => (
              <Option value={v}>{v}</Option>
            ))}
          </Select>
        </Modal>
      </div>
    </div>
  )
}
