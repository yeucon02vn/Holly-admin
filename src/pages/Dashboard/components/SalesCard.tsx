import { Card, Col, DatePicker, Row, Tabs } from 'antd'
import { RangePickerProps } from 'antd/es/date-picker/generatePicker'
import moment from 'moment'
import numeral from 'numeral'
import React from 'react'
import { formatMessage, FormattedMessage } from 'umi'
import { VisitDataType } from '../data.d'
import styles from '../style.less'
import { generateName } from '../_mock'
import { Bar } from './Charts'

const { RangePicker } = DatePicker
const { TabPane } = Tabs

type RangePickerValue = RangePickerProps<moment.Moment>['value']

const SalesCard = ({
  rangePickerValue,
  // salesData,
  isActive,
  handleRangePickerChange,
  loading,
  selectDate,
}: {
  rangePickerValue: RangePickerValue
  isActive: (key: 'today' | 'week' | 'month' | 'year') => string
  salesData: VisitDataType[]
  loading: boolean
  handleRangePickerChange: (dates: RangePickerValue, dateStrings: [string, string]) => void
  selectDate: (key: 'today' | 'week' | 'month' | 'year') => void
}) => {
  const calcSaleData = () => {
    const temp = []
    for (let i = 0; i < 12; i += 1) {
      temp.push({
        x: `${i + 1}`,
        y: Math.floor(Math.random() * 1000) + 200,
      })
    }

    return temp
  }

  const rankingListData: { title: string; total: number }[] = []
  for (let i = 0; i < 7; i += 1) {
    rankingListData.push({
      title: formatMessage({ id: generateName() }, { no: i }),
      total: Math.floor(Math.random() * 12) + 200,
    })
  }

  const salesData = calcSaleData()

  return (
    <Card loading={loading} bordered={false} bodyStyle={{ padding: 0 }}>
      <div className={styles.salesCard}>
        <Tabs
          tabBarExtraContent={
            <div className={styles.salesExtraWrap}>
              <div className={styles.salesExtra}>
                <a className={isActive('year')} onClick={() => selectDate('year')}>
                  <FormattedMessage id="dashboard.analysis.all-year" defaultMessage="All Year" />
                </a>
              </div>
            </div>
          }
          size="large"
          tabBarStyle={{ marginBottom: 24 }}
        >
          <TabPane
            tab={<FormattedMessage id="dashboard.analysis.sales" defaultMessage="Sales" />}
            key="sales"
          >
            <Row>
              <Col xl={16} lg={12} md={12} sm={24} xs={24}>
                <div className={styles.salesBar}>
                  <Bar
                    height={295}
                    title={
                      <FormattedMessage
                        id="dashboard.analysis.sales-trend"
                        defaultMessage="Sales Trend"
                      />
                    }
                    data={salesData}
                  />
                </div>
              </Col>
              <Col xl={8} lg={12} md={12} sm={24} xs={24}>
                <div className={styles.salesRank}>
                  <h4 className={styles.rankingTitle}>
                    <FormattedMessage
                      id="dashboard.analysis.sales-ranking"
                      defaultMessage="Ranking"
                    />
                  </h4>
                  <ul className={styles.rankingList}>
                    {rankingListData.map((item, i) => (
                      <li key={item.title}>
                        <span
                          className={`${styles.rankingItemNumber} ${i < 3 ? styles.active : ''}`}
                        >
                          {i + 1}
                        </span>
                        <span className={styles.rankingItemTitle} title={item.title}>
                          {item.title}
                        </span>
                        <span className={styles.rankingItemValue}>
                          {numeral(item.total).format('0,0')}
                        </span>
                      </li>
                    ))}
                  </ul>
                </div>
              </Col>
            </Row>
          </TabPane>
          <TabPane
            tab={<FormattedMessage id="dashboard.analysis.visits" defaultMessage="Visits" />}
            key="views"
          >
            <Row>
              <Col xl={16} lg={12} md={12} sm={24} xs={24}>
                <div className={styles.salesBar}>
                  <Bar
                    height={292}
                    title={
                      <FormattedMessage
                        id="dashboard.analysis.visits-trend"
                        defaultMessage="Visits Trend"
                      />
                    }
                    data={salesData}
                  />
                </div>
              </Col>
              <Col xl={8} lg={12} md={12} sm={24} xs={24}>
                <div className={styles.salesRank}>
                  <h4 className={styles.rankingTitle}>
                    <FormattedMessage
                      id="dashboard.analysis.visits-ranking"
                      defaultMessage="Visits Ranking"
                    />
                  </h4>
                  <ul className={styles.rankingList}>
                    {rankingListData.map((item, i) => (
                      <li key={item.title}>
                        <span
                          className={`${styles.rankingItemNumber} ${i < 3 ? styles.active : ''}`}
                        >
                          {i + 1}
                        </span>
                        <span className={styles.rankingItemTitle} title={item.title}>
                          {item.title}
                        </span>
                        <span>{numeral(item.total).format('0,0')}</span>
                      </li>
                    ))}
                  </ul>
                </div>
              </Col>
            </Row>
          </TabPane>
        </Tabs>
      </div>
    </Card>
  )
}

export default SalesCard
