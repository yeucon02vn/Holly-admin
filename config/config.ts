// https://umijs.org/config/
import { defineConfig } from 'umi'
import defaultSettings from './defaultSettings'
import proxy from './proxy'
const { REACT_APP_ENV } = process.env
export default defineConfig({
  hash: true,
  antd: {},
  dva: {
    hmr: true,
  },
  layout: {
    name: 'Holly Admin Pro',
    locale: true,
    siderWidth: 208,
  },
  locale: {
    // default zh-CN
    default: 'en-US',
    // default true, when it is true, will use `navigator.language` overwrite default
    antd: true,
    baseNavigator: true,
  },
  dynamicImport: {
    loading: '@/components/PageLoading/index',
  },
  targets: {
    ie: 11,
  },
  // umi routes: https://umijs.org/docs/routing
  routes: [
    {
      path: '/user',
      layout: false,
      routes: [
        {
          name: 'login',
          path: '/user/login',
          component: './user/login',
        },
      ],
    },
    {
      name: 'Dashboard',
      icon: 'smile',
      path: '/',
      component: './Dashboard',
    },
    {
      path: '/admin',
      name: 'admin',
      icon: 'crown',
      access: 'canAdmin',
      routes: [
        {
          name: 'View all account',
          icon: 'smile',
          path: '/admin/view-all-account',
          component: './Account/ViewAll',
        },
        {
          name: 'Add account',
          icon: 'smile',
          path: '/admin/add-account',
          component: './AddAccount',
        },
      ],
    },
    {
      name: 'Product',
      icon: 'fire',
      path: '/product',
      // component: './product',
      routes: [
        {
          name: 'View all',
          icon: 'smile',
          path: '/product/view-all',
          component: './product/view-all',
        },
        {
          name: 'Add new',
          icon: 'smile',
          path: '/product/add-product',
          component: './product/AddProduct',
        },
      ],
    },
    {
      name: 'Add provider',
      icon: 'property-safety',
      path: '/provider',
      routes: [
        {
          name: 'View all',
          icon: 'fund-view',
          path: '/provider/view-all',
          component: './provider/ViewAll',
        },

        {
          name: 'Add provider',
          icon: 'smile',
          path: '/provider/add-provider',
          component: './provider/AddProvider',
        },
      ],
    },
    {
      name: 'Order',
      icon: 'shopping',
      path: '/order',
      routes: [
        {
          name: 'View all',
          icon: 'smile',
          path: 'order/order-view-all',
          component: './order-general/OrderViewAll',
        },
      ],
    },
    {
      name: 'Feedback',
      icon: 'customer-service',
      path: '/feed-back',
      component: './Feedback',
    },
    {
      component: './404',
    },
  ],
  // Theme for antd: https://ant.design/docs/react/customize-theme-cn
  theme: {
    // ...darkTheme,
    'primary-color': defaultSettings.primaryColor,
  },
  ignoreMomentLocale: true,
  proxy: proxy[REACT_APP_ENV || 'dev'],
  manifest: {
    basePath: '/',
  },
})
