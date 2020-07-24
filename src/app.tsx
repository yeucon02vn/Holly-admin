import Footer from '@/components/Footer'
import RightContent from '@/components/RightContent'
import { BasicLayoutProps, Settings as LayoutSettings } from '@ant-design/pro-layout'
import { notification } from 'antd'
import React from 'react'
import { history, RequestConfig } from 'umi'
import defaultSettings from '../config/defaultSettings'
import { queryCurrent } from './services/user'
import './tailwind/tailwind.less'

export async function getInitialState(): Promise<{
  currentUser?: API.UserInfo
  settings?: LayoutSettings
}> {
  // 如果是登录页面，不执行
  if (history.location.pathname !== '/user/login') {
    try {
      const currentUser = await queryCurrent()
      console.log('currentUser', currentUser)
      return {
        currentUser,
        settings: defaultSettings,
      }
    } catch (error) {
      history.push('/user/login')
    }
  }

  return {
    settings: defaultSettings,
  }
}

export const layout = ({
  initialState,
}: {
  initialState: { settings?: LayoutSettings }
}): BasicLayoutProps => {
  return {
    rightContentRender: () => <RightContent />,
    disableContentMargin: false,
    footerRender: () => <Footer />,
    menuHeaderRender: undefined,
    ...initialState?.settings,
  }
}

const codeMessage = {
  200: 'The server successfully returned the requested data.',
  201: 'New or modified data is successful.  ',
  202: 'A request has entered the background queue (asynchronous task).',
  204: 'The data was deleted successfully.',
  400: 'There was an error in the requested request, and the server did not create or modify data.',
  401: 'The user does not have permission (token, user name, wrong password).',
  403: 'The user is authorized, but access is prohibited.',
  404: 'The request issued was for a non-existent record, and the server did not operate it.',
  405: 'Request method is not allowed.',
  406: 'The requested format is not available.',
  410: 'The requested resource is permanently deleted and will no longer be available.',
  422: 'When creating an object, a validation error occurred.',
  500: 'An error occurred on the server, please check the server.',
  502: 'Gateway error.',
  503: 'The service is unavailable, the server is temporarily overloaded or maintained.',
  504: 'Gateway timeout.',
}

/**
 * 异常处理程序
 */
const errorHandler = (error: { response: Response }) => {
  const { response } = error
  if (response && response.status) {
    const errorText = codeMessage[response.status] || response.statusText
    const { status, url } = response

    notification.error({
      message: `Request error ${status}: ${url}`,
      description: errorText,
    })
  }

  if (!response) {
    notification.error({
      description: 'Your network is abnormal and cannot connect to the server',
      message: 'Network anomaly',
    })
  }
  throw error
}

export const request: RequestConfig = {
  errorHandler,
}
