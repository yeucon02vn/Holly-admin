import { appRequest } from '@/services/api-config'
import { request } from 'umi'
import { useQuery } from 'react-query'

const adminEndpoint = 'Admin'
const endpoint = 'Accounts'

export async function query() {
  return request<API.CurrentUser[]>('/api/users')
}

export async function queryCurrent() {
  return appRequest<API.UserInfo>(`${endpoint}/get-user-info`)
}

export async function queryNotices(): Promise<any> {
  return request<{ data: API.NoticeIconData[] }>('/api/notices')
}

export const mutDeleteUser = async (id: string) => {
  return appRequest<API.UserInfo>(`${adminEndpoint}/delete/${id}`, { method: 'POST' })
}

export const queryGetAllUser = async () => {
  return appRequest<API.AllUserData[]>(`${adminEndpoint}/get-all`)
}

export const useQueryGetAllUser = () => {
  return useQuery('getAllUser', queryGetAllUser)
}

export const changeAccountType = (data: { id: string; type: number }) => {
  return appRequest<API.UserInfo>(`${adminEndpoint}/change-account-type`, {
    data,
    method: 'POST',
  })
}
export interface SignUpInput {
  email: string
  name: string
  password: string
  type: number
}

export const signUp = (input: SignUpInput) => {
  return appRequest<API.UserInfo>(`${adminEndpoint}/sign-up`, {
    data: input,
    method: 'POST',
  })
}
