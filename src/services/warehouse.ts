import { useQuery } from 'react-query'
import { appRequest } from './api-config'

const BASE_END_POINT = 'Warehouse/'

const detailUrls = {
  updateStock: '',
  getByOnProductId: 'get-quantity',
}

Object.keys(detailUrls).map((key) => {
  detailUrls[key] = BASE_END_POINT + detailUrls[key]
  return key
})

type UpdateStockInput = {
  productId: string
  quantity: number
}

export const updateStock = (input: UpdateStockInput) => {
  const { productId, quantity } = input
  return appRequest(detailUrls.updateStock, {
    method: 'put',
    params: {
      productId,
      quantity,
    },
  })
}

export const getByOnProductId = (_: any, productId: string) => {
  return appRequest<number>(detailUrls.getByOnProductId, {
    params: {
      productId,
    },
  })
}

export const useGetQuantityByProductId = (productId: string) => {
  return useQuery(['useGetQuantityByProductId', productId], getByOnProductId)
}
