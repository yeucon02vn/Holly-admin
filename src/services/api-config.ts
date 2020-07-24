import { strings } from '@/utils/strings'
import { request } from 'umi'
import { RequestOptionsInit } from 'umi-request'

const version = 'api/v1'

export const ROOT_URL = `https://localhost:5001/${version}`

export const CLIENT_URL = `https://hollypocket.netlify.app`

export const appRequest = async <T>(
  endPoints: string,
  options?: RequestOptionsInit,
): Promise<T> => {
  const url = `${ROOT_URL}/${endPoints}`
  const idToken = localStorage.getItem(strings.token)
  const cloneOptions: any = { ...options }
  if (idToken) {
    cloneOptions.headers = { ...cloneOptions?.headers, authorization: `Bearer ${idToken}` }
  }
  // return request<T>(url, cloneOptions)
  return new Promise(async (resolve, reject) => {
    request<T>(url, cloneOptions).then((d: any) => {
      if (d?.error) return reject(new Error(d?.message))
      resolve(d?.data)
    })
  })
}
