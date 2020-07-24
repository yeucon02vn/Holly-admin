import { StatusProduct } from '@/pages/product/view-all/ModalChangeStatusProduct'
import { useInfiniteQuery, useQuery } from 'react-query'
import { appRequest as AppAPI, appRequest } from './api-config'

const BASE_END_POINT = 'Products/'

const detailUrls = {
  getProducts: 'get-all-for-admin',
  getProduct: 'get',
  getProductsByIds: 'get-products-with-id',
  getByProvider: 'Get-With-Provider',
  getByRate: 'Get-With-Rate',
  getByPrice: 'Get-With-Range-Price',
  getByDiscount: 'Get-With-Higher-Discount',
  create: 'create',
  searchProduct: 'search',
  delete: '',
  undelete: 'undelete/',
  search: 'search',
}

// eslint-disable-next-line
Object.keys(detailUrls).map((key) => {
  detailUrls[key] = BASE_END_POINT + detailUrls[key]
})

export const productsUrl = detailUrls

// export const getProductGeneral = ({ page }: { page?: number }) =>
// fetch(`${detailUrls.getGeneral}?pageNumber=${page || 0}&pageSize=10`)

export const getProductsWithCustomUrl = async (
  _: any,
  url: string,
  cursor: any,
): Promise<API.ProductsResponseData> => {
  const data: any = await AppAPI<API.ProductsResponseData>(
    `${url}?pageNumber=${cursor || 1}&pageSize=10`,
  )
  return data
}

export const getProductsGeneral = async (
  _: any,
  cursor: any,
): Promise<API.ProductsResponseData> => {
  const data: any = await AppAPI<API.ProductsResponseData>(
    `${detailUrls.getProducts}?pageNumber=${cursor || 1}&pageSize=10`,
  )
  return data
}

export const getProduct = async (_: any, id: string) => {
  const data: any = await AppAPI<API.ProductData>(`${detailUrls.getProduct}/${id}`)
  return data
}

export const useGetProduct = (id: string) => {
  return useQuery(['getProductById', id], getProduct)
}

export const getProductsByIds = async (_: any, ids: string[]): Promise<API.ProductData[]> => {
  let params = ''
  ids.forEach((v, i) => {
    if (i !== 0) params += '&'
    params += `ids=${v}`
  })
  return await AppAPI(`${detailUrls.getProductsByIds}?${params}`)
}

export const useGetProductsByIdsQuery = (ids: string[]) => {
  return useQuery(['getProductsByIds', ids], getProductsByIds)
}

export const useQueryGetProductsByProvider = (providerName: string) => {
  return useInfiniteQuery(
    'getProductByProvider',
    async (key, nextId = 0) => {
      const data = await AppAPI<API.ProductsResponseData>(
        `${detailUrls.getByProvider}/${providerName}?pageSize=10&pageNumber=${nextId}`,
      )
      return data
    },
    {
      getFetchMore: (lastGroup) => {
        if (!lastGroup?.pagination?.hasNext) return false
        return (lastGroup?.pagination?.currentPage || 1) + 1
      },
      initialData: [],
      enabled: !!providerName,
    },
  )
}

export const useQueryGetProductsByRate = (rate: number) => {
  return useInfiniteQuery<API.ProductsResponseData, any, any>(
    'getProductByRate',
    async (key, nextId = 1) => {
      const url = `${detailUrls.getByRate}/${rate}?pageSize=10&pageNumber=${nextId}`
      const data = await AppAPI<API.ProductsResponseData>(url)
      return data
    },
    {
      getFetchMore: (lastGroup) => {
        if (!lastGroup?.pagination?.hasNext) return false
        return (lastGroup?.pagination?.currentPage || 1) + 1
      },
      initialData: [],
      enabled: !!rate,
    },
  )
}
export const useQueryGetProductsByDiscount = (discount: number) => {
  return useInfiniteQuery(
    'getProductByDiscount',
    async (key, nextId = 1) => {
      const url = `${detailUrls.getByDiscount}/${discount}?pageSize=10&pageNumber=${nextId}`
      const data = await AppAPI<API.ProductsResponseData>(url)
      return data
    },
    {
      getFetchMore: (lastGroup) => {
        if (!lastGroup?.pagination?.hasNext) return false
        return (lastGroup?.pagination?.currentPage || 1) + 1
      },
      initialData: [],
      enabled: !!discount,
    },
  )
}

export const useQueryGetProductsByPrice = (min: number, max: number) => {
  return useInfiniteQuery(
    'getProductByPrice',
    async (key, nextId = 1) => {
      const url = `${detailUrls.getByPrice}?fromPrice=${min}&toPrice=${max}&pageSize=10&pageNumber=${nextId}`
      const data = await AppAPI<API.ProductsResponseData>(url)
      return data
    },
    {
      getFetchMore: (lastGroup) => {
        if (!lastGroup?.pagination?.hasNext) return false
        return (lastGroup?.pagination?.currentPage || 1) + 1
      },
      initialData: [],
      enabled: !!min && !!max,
    },
  )
}

export const createProduct = ({
  input,
  formData,
}: {
  input: API.CreateProductInput
  formData: FormData
}) => {
  let tags = ''
  input?.Info?.tagName?.forEach((v, i) => {
    tags += `&Info.TagName=${v}`
  })

  let descriptions = ''
  input?.Info?.descriptions?.forEach((v, i) => {
    descriptions += `&Info.Descriptions=${v}`
  })

  const params = `ProductName=${input.ProductName}&Price=${input.Price}&Provider=${input.Provider}${descriptions}${tags}&quantity=${input.quantity}`
  const url = `${detailUrls.create}?${params}`
  return appRequest(url, {
    method: 'POST',
    body: formData,
  })
}

export const changeProductStatus = (id: string, type: number) => {
  const method = type === StatusProduct.active ? detailUrls.undelete : detailUrls.delete
  const url = `${method}${id}`
  return appRequest(url, {
    method: type === StatusProduct.active ? 'POST' : 'DELETE',
  })
}

export const searchProducts = (_: any, query: string) => {
  const url = `${detailUrls.search}/${query}`
  return appRequest(url)
}
