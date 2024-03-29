import { EllipsisOutlined } from '@ant-design/icons'
import { Col, Dropdown, Menu, Row } from 'antd'
import React, { Component, Suspense } from 'react'
import { GridContent } from '@ant-design/pro-layout'
import { RadioChangeEvent } from 'antd/es/radio'
import { RangePickerProps } from 'antd/es/date-picker/generatePicker'
import moment from 'moment'
import { connect, Dispatch } from 'umi'

import PageLoading from './components/PageLoading'
import { getTimeDistance } from './utils/utils'
import { AnalysisData } from './data.d'
import styles from './style.less'

const IntroduceRow = React.lazy(() => import('./components/IntroduceRow'))
const SalesCard = React.lazy(() => import('./components/SalesCard'))
const TopSearch = React.lazy(() => import('./components/TopSearch'))
const ProportionSales = React.lazy(() => import('./components/ProportionSales'))
const OfflineData = React.lazy(() => import('./components/OfflineData'))

type RangePickerValue = RangePickerProps<moment.Moment>['value']

interface DashboardProps {
  dashboard: AnalysisData
  dispatch: Dispatch<any>
  loading: boolean
}

interface DashboardState {
  salesType: 'all' | 'online' | 'stores'
  currentTabKey: string
  rangePickerValue: RangePickerValue
}

class Dashboard extends Component<DashboardProps, DashboardState> {
  state: DashboardState = {
    salesType: 'all',
    currentTabKey: '',
    rangePickerValue: getTimeDistance('year'),
  }

  reqRef: number = 0

  timeoutId: number = 0

  componentDidMount() {
    const { dispatch } = this.props
    this.reqRef = requestAnimationFrame(() => {
      dispatch({
        type: 'dashboard/fetch',
      })
    })
  }

  componentWillUnmount() {
    const { dispatch } = this.props
    dispatch({
      type: 'dashboard/clear',
    })
    cancelAnimationFrame(this.reqRef)
    clearTimeout(this.timeoutId)
  }

  handleChangeSalesType = (e: RadioChangeEvent) => {
    this.setState({
      salesType: e.target.value,
    })
  }

  handleTabChange = (key: string) => {
    this.setState({
      currentTabKey: key,
    })
  }

  handleRangePickerChange = (rangePickerValue: RangePickerValue) => {
    const { dispatch } = this.props
    this.setState({
      rangePickerValue,
    })

    dispatch({
      type: 'dashboard/fetchSalesData',
    })
  }

  selectDate = (type: 'today' | 'week' | 'month' | 'year') => {
    const { dispatch } = this.props
    this.setState({
      rangePickerValue: getTimeDistance(type),
    })

    dispatch({
      type: 'dashboard/fetchSalesData',
    })
  }

  isActive = (type: 'today' | 'week' | 'month' | 'year') => {
    const { rangePickerValue } = this.state
    if (!rangePickerValue) {
      return ''
    }
    const value = getTimeDistance(type)
    if (!value) {
      return ''
    }
    if (!rangePickerValue[0] || !rangePickerValue[1]) {
      return ''
    }
    if (
      rangePickerValue[0].isSame(value[0] as moment.Moment, 'day') &&
      rangePickerValue[1].isSame(value[1] as moment.Moment, 'day')
    ) {
      return styles.currentDate
    }
    return ''
  }

  render() {
    const { rangePickerValue, salesType, currentTabKey } = this.state
    const { dashboard, loading } = this.props
    const {
      visitData,
      visitData2,
      salesData,
      searchData,
      offlineData,
      offlineChartData,
      salesTypeData,
      salesTypeDataOnline,
      salesTypeDataOffline,
    } = dashboard

    console.log('dashboard', dashboard)
    let salesPieData
    if (salesType === 'all') {
      salesPieData = salesTypeData
    } else {
      salesPieData = salesType === 'online' ? salesTypeDataOnline : salesTypeDataOffline
    }
    const menu = (
      <Menu>
        <Menu.Item>操作一</Menu.Item>
        <Menu.Item>操作二</Menu.Item>
      </Menu>
    )

    const dropdownGroup = (
      <span className={styles.iconGroup}>
        <Dropdown overlay={menu} placement="bottomRight">
          <EllipsisOutlined />
        </Dropdown>
      </span>
    )

    const activeKey = currentTabKey || (offlineData[0] && offlineData[0].name)
    return (
      <GridContent>
        <React.Fragment>
          <Suspense fallback={<PageLoading />}>
            <IntroduceRow loading={loading} visitData={visitData} />
          </Suspense>
          <Suspense fallback={null}>
            <SalesCard
              rangePickerValue={rangePickerValue}
              salesData={salesData}
              isActive={this.isActive}
              handleRangePickerChange={this.handleRangePickerChange}
              loading={loading}
              selectDate={this.selectDate}
            />
          </Suspense>
          <Row
            gutter={24}
            style={{
              marginTop: 24,
            }}
          >
            <Col xl={12} lg={24} md={24} sm={24} xs={24}>
              <Suspense fallback={null}>
                <TopSearch
                  loading={loading}
                  visitData2={visitData2}
                  searchData={searchData}
                  dropdownGroup={dropdownGroup}
                />
              </Suspense>
            </Col>
            <Col xl={12} lg={24} md={24} sm={24} xs={24}>
              <Suspense fallback={null}>
                <ProportionSales
                  dropdownGroup={dropdownGroup}
                  salesType={salesType}
                  loading={loading}
                  salesPieData={salesPieData}
                  handleChangeSalesType={this.handleChangeSalesType}
                />
              </Suspense>
            </Col>
          </Row>
        </React.Fragment>
      </GridContent>
    )
  }
}

export default connect(
  ({
    dashboard,
    loading,
  }: {
    dashboard: any
    loading: {
      effects: { [key: string]: boolean }
    }
  }) => ({
    dashboard,
    loading: loading.effects['dashboard/fetch'],
  }),
)(Dashboard)
