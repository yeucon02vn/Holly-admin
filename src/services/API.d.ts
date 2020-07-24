declare namespace API {
  export interface CurrentUser {
    avatar?: string
    name?: string
    title?: string
    group?: string
    signature?: string
    tags?: {
      key: string
      label: string
    }[]
    userid?: string
    access?: 'user' | 'guest' | 'admin'
    unreadCount?: number
  }

  export interface BaseResponse {
    error: boolean
    message: string
  }

  export interface LoginStateType {
    info: UserInfo
    token: string
  }

  export interface UserInfo {
    email: string
    addresses: any[]
    phoneNumber: null
    name: string
    gender: null
    accountType: number
    id: string
  }

  export interface AllUserData {
    id: string
    email: string
    addresses: any[]
    phoneNumber: null
    name: string
    gender: null
    password: null
    token: null
    accountType: number
    isDeleted: boolean
  }

  export interface NoticeIconData {
    id: string
    key: string
    avatar: string
    title: string
    datetime: string
    type: string
    read?: boolean
    description: string
    clickClose?: boolean
    extra: any
    status: string
  }
  export interface ProductsResponseData {
    items: ProductData[]
    pagination: Pagination
  }

  export interface FeedbackResponse {
    items: Feedback[]
    pagination: Pagination
  }

  export interface Feedback {
    id: string
    email?: string
    title?: string
    description?: string
    orderId?: string
    isRead?: boolean
    createdDate?: string
  }

  export interface ProductData {
    id: string
    productName: string
    price: number
    provider: string
    rate: number
    discount: number
    questions: any[]
    info: Info
    pictures: string[]
    thumbnailId: string
    quantityInStock: number
  }

  export interface CreateProductInput {
    ProductName: string
    Price: number
    Provider: string
    Info: Info
    quantity: number
  }

  export interface Info {
    descriptions: string[]
    tagName: string[]
  }

  export interface Pagination {
    currentPage?: number
    totalPages?: number
    pageSize?: number
    totalCount?: number
    hasPrevious?: boolean
    hasNext?: boolean
  }
  export interface Provider {
    id: string
    name: string
    description: string
  }
  export interface AccountInfo {
    id: string
    email: string
    addresss: AddressModel[]
    phoneNumber?: any
    name?: string
    password?: any
    gender?: string
    token: string
  }

  export interface CartResponse {
    id: string
    userId: string
    products: Cart[]
  }

  export interface Cart {
    productId: string
    amount: number
  }

  export interface OrderInput {
    note: string
    receiverAddress: string
    orderDate: Date
    phone: string
    name: string
    cashType: string
  }

  export interface Orderinfo {
    carts?: Carts
    note?: string
    receiverAdderss?: null
    orderDate?: Date
    deliveryDate?: Date
    cashType?: string
    status?: string
  }
  export interface Carts {
    product?: Product[]
  }

  export interface GetOrdersResponse {
    id?: string
    accountId?: string
    orderinfo?: Orderinfo
    isDeleted?: boolean
  }

  export interface FavoriteResponse {
    id: string
    userId: string
    productId: string[]
  }

  export interface AccountResponse {
    info: AccountInfo
    token: string
  }

  export interface QuestionInput {
    title: string
    decriptions: string
    productId: string
  }

  export interface QuestionResponse {
    result: QuestionResult
    id: number
    exception: null
    status: number
    isCanceled: boolean
    isCompleted: boolean
    isCompletedSuccessfully: boolean
    creationOptions: number
    asyncState: null
    isFaulted: boolean
  }

  export interface QuestionResult {
    items: QuestionItem[]
    pagination: Pagination
  }

  export interface QuestionItem {
    id: string
    userId: string
    productId: string
    answer: null
    title: string
    decriptions: string
  }

  export interface GetListBoughtProductResponse {
    accountId: string
    carts: BoughtProductInfo[]
  }

  export interface BoughtProductInfo {
    productId: string
    amount: number
    name: string
    provider: string
    price: number
  }

  export interface GetListOrders {
    id: string
    accountId: string
    orderinfo: ListOrderinfo
    isDeleted: boolean
  }

  export interface ListOrderinfo {
    carts: BoughtProductInfo[]
    note: string
    receiverAdderss: string
    orderDate: Date
    name: string
    phone: string
    cashType: string
    status: string
  }

  export interface APIResponse<T> {
    data?: T
    message?: string
    error?: boolean
  }
}
