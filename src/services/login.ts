import { request } from 'umi'
import { appRequest } from './api-config'

const endPoint = 'admin'

export interface LoginParamsType {
  email: string
  password: string
  mobile: string
  captcha: string
  type: string
}

export async function fakeAccountLogin(params: LoginParamsType) {
  return request<API.LoginStateType>('/api/login/account', {
    method: 'POST',
    data: params,
  })
}

export async function getFakeCaptcha(mobile: string) {
  return request(`/api/login/captcha?mobile=${mobile}`)
}

export async function outLogin() {
  return request('/api/login/outLogin')
}

export async function login(params: LoginParamsType) {
  return appRequest<API.LoginStateType>(`${endPoint}/sign-in`, {
    method: 'POST',
    data: params,
  })
}
