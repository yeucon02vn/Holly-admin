import React from 'react'
import { PageContainer } from '@ant-design/pro-layout'
import { Card, Typography, Alert } from 'antd'
import styles from './Welcome.less'
import FormRegister from './FormRegister'
import TableBasic from './TableBasic'
import SelectBasic from './SelectBasic'
import AvatarDynamic from './AvatarDynamic'
export default (): React.ReactNode => (
  <PageContainer>
    <AvatarDynamic />
    <SelectBasic />
    <FormRegister />
    <TableBasic />
    <p
      style={{
        textAlign: 'center',
        marginTop: 24,
      }}
    >
      <div className="card">test card tailwind</div>
      Want to add more pages? Please refer to{' '}
      <a href="https://pro.ant.design/docs/block-cn" target="_blank" rel="noopener noreferrer">
        use block
      </a>
      。
    </p>
  </PageContainer>
)
