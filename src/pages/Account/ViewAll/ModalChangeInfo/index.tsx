import { Modal, Select } from 'antd'
import React from 'react'
import styles from './index.less'
import { accountTypes } from '..'

const { Option } = Select

interface ModalChangeInfoProps {
  id: string
  handleOk: (id: string, value: number) => void
  handleCancel: () => void
  show: boolean
}

export const ModalChangeInfo: React.FC<ModalChangeInfoProps> = (props) => {
  const { id, handleCancel, handleOk, show } = props
  const [value, setValue] = React.useState(0)

  const handleChange = (v: number) => {
    setValue(v)
  }

  return (
    <div className={styles.container}>
      <div id="components-modal-demo-basic">
        <Modal
          title="Basic Modal"
          visible={show}
          onOk={() => handleOk(id, value)}
          onCancel={handleCancel}
        >
          <Select defaultValue={0} style={{ width: 220 }} onChange={handleChange}>
            {accountTypes.map((v, i) => {
              return <Option value={i}>{v}</Option>
            })}
          </Select>
        </Modal>
      </div>
    </div>
  )
}
