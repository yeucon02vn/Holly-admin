import { useQuery } from 'react-query'
import { appRequest } from './api-config'

const BASE_END_POINT = 'Order/'

const detailUrls = {
  getAll: 'get-all',
  update: 'UpdateStatus',
  search: 'Search',
}

Object.keys(detailUrls).map((key) => {
  detailUrls[key] = BASE_END_POINT + detailUrls[key]
  return key
})

export const orderUrls = detailUrls

export const getAllOrders = async (): Promise<API.GetOrdersResponse[]> => {
  const url = `Order/get-all`
  return appRequest(url)
}

export const getOrderWithUrl = async (_: any, url: string): Promise<API.GetOrdersResponse[]> => {
  return appRequest(url)
}

export const useQueryGetAllOrders = () => {
  return useQuery('getAllOrders', getAllOrders)
}

export const updateOrderStatus = ({ id, status }: { id: string; status: string }) => {
  return appRequest(detailUrls.update, {
    params: {
      id,
      status,
    },
    method: 'POST',
  })
}

export const searchOrder = async (): Promise<API.GetOrdersResponse[]> => {
  return appRequest(detailUrls.search)
}
