import { useQuery } from 'react-query'
import { appRequest } from './api-config'

const BASE_END_POINT = 'Providers/'

const detailUrls = {
  create: '',
  getAll: '',
}

Object.keys(detailUrls).map((key) => {
  detailUrls[key] = BASE_END_POINT + detailUrls[key]
  return key
})

interface ProviderInput {
  name: string
  description: string
}

export const createProvider = (data: ProviderInput) => {
  return appRequest(detailUrls.create, {
    method: 'POST',
    data,
  })
}

export const getByProviders = () => {
  return appRequest<API.Provider[]>(detailUrls.getAll)
}

export const useQueryGetProviders = () => {
  return useQuery('useQueryGetProviders', getByProviders)
}
