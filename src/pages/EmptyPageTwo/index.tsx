import { useQueryGetAllUser } from '@/services/user'
import { PageContainer } from '@ant-design/pro-layout'
import React from 'react'
import styles from './index.less'

export default () => {
  const { data } = useQueryGetAllUser()
  return (
    <PageContainer content="emptypagetwo" className={styles.main}>
      <div className="flex flex-col">
        {data?.map((v) => {
          return <p key={v.id}>{v.name}</p>
        })}
      </div>
    </PageContainer>
  )
}
