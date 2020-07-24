import { appRequest } from './api-config'

const BASE_END_POINT = 'Feedbacks/'

const detailUrls = {
  getAll: 'get-all',
  markAsRead: 'mark-as-read',
}

Object.keys(detailUrls).map((key) => {
  detailUrls[key] = BASE_END_POINT + detailUrls[key]
  return key
})

export const feedbackUrls = detailUrls

export const getFeedbacksWithCustomUrl = async (
  _: any,
  url: string,
  cursor: any,
): Promise<API.FeedbackResponse> => {
  const data: any = await appRequest<API.FeedbackResponse>(url, {
    params: {
      pageNumber: cursor,
      pageSize: 10,
    },
  })
  return data
}

interface MarkFeedbackInput {
  id: string
  isRead: boolean
}

export const markReadFeedback = async (data: MarkFeedbackInput) => {
  const rs = await appRequest<API.Feedback>(detailUrls.markAsRead, {
    method: 'post',
    data,
  })
  return rs
}
