import { AlipayCircleOutlined, TaobaoCircleOutlined, WeiboCircleOutlined } from '@ant-design/icons'
import { Alert, Checkbox, message } from 'antd'
import React, { useState } from 'react'
import { Link, SelectLang, history, useModel } from 'umi'
import { getPageQuery } from '@/utils/utils'
import logo from '@/assets/logo.svg'
import { LoginParamsType, fakeAccountLogin, login } from '@/services/login'
import { strings } from '@/utils/strings'
import { useMutation } from 'react-query'
import LoginFrom from './components/Login'
import styles from './style.less'

const { Tab, Username, Password, Mobile, Captcha, Submit } = LoginFrom

const LoginMessage: React.FC<{
  content: string
}> = ({ content }) => (
  <Alert
    style={{
      marginBottom: 24,
    }}
    message={content}
    type="error"
    showIcon
  />
)

/**
 * 此方法会跳转到 redirect 参数所在的位置
 */
const replaceGoto = () => {
  const urlParams = new URL(window.location.href)
  const params = getPageQuery()
  let { redirect } = params as { redirect: string }
  if (redirect) {
    const redirectUrlParams = new URL(redirect)
    if (redirectUrlParams.origin === urlParams.origin) {
      redirect = redirect.substr(urlParams.origin.length)
      if (redirect.match(/^\/.*#/)) {
        redirect = redirect.substr(redirect.indexOf('#') + 1)
      }
    } else {
      window.location.href = '/'
      return
    }
  }
  history.replace(redirect || '/')
}

const Login: React.FC<{}> = () => {
  const [userLoginState, setUserLoginState] = useState({
    status: 'none',
    type: 'account',
  })

  const { refresh } = useModel('@@initialState')
  const [autoLogin, setAutoLogin] = useState(true)
  const [type, setType] = useState<string>('account')

  const [mutate, { status }] = useMutation(login, {
    onError(e) {
      message.error(e?.message)
    },
    onSuccess(d) {
      localStorage.setItem(strings.token, d.token)
      replaceGoto()
      setTimeout(() => {
        refresh()
      }, 0)
    },
  })
  const submitting = status === 'loading'

  const handleSubmit = async (values: LoginParamsType) => {
    mutate({ ...values })
  }

  const { type: loginType } = userLoginState

  return (
    <div className={styles.container}>
      <div className={styles.lang}>
        <SelectLang />
      </div>
      <div className={styles.content}>
        <div className={styles.top}>
          <div className={styles.header}>
            <Link to="/">
              <img alt="logo" className={styles.logo} src={logo} />
              <span className={styles.title}>Holly Admin</span>
            </Link>
          </div>
          <div className={styles.desc}>Holly Admin</div>
        </div>

        <div className={styles.main}>
          <LoginFrom activeKey={type} onTabChange={setType} onSubmit={handleSubmit}>
            <Tab key="account" tab="Account login">
              {status === 'error' && loginType === 'account' && !submitting && (
                <LoginMessage content="Incorrect account or password" />
              )}

              <Username
                name="email"
                placeholder="default emal: admin or user"
                rules={[
                  {
                    required: true,
                    message: 'Invalid email',
                  },
                ]}
              />
              <Password
                name="password"
                placeholder="Pefault password: ant.design"
                rules={[
                  {
                    required: true,
                    message: 'Invalid password',
                  },
                ]}
              />
            </Tab>
            <Tab key="mobile" tab="Phone number login">
              {status === 'error' && loginType === 'mobile' && !submitting && (
                <LoginMessage content="Phone number login" />
              )}
              <Mobile
                name="mobile"
                placeholder="手机号"
                rules={[
                  {
                    required: true,
                    message: '请输入手机号！',
                  },
                  {
                    pattern: /^1\d{10}$/,
                    message: '手机号格式错误！',
                  },
                ]}
              />
              <Captcha
                name="captcha"
                placeholder="验证码"
                countDown={120}
                getCaptchaButtonText=""
                getCaptchaSecondText="秒"
                rules={[
                  {
                    required: true,
                    message: '请输入验证码！',
                  },
                ]}
              />
            </Tab>
            <div>
              <Checkbox checked={autoLogin} onChange={(e) => setAutoLogin(e.target.checked)}>
                Auto login
              </Checkbox>
              <a
                style={{
                  float: 'right',
                }}
              >
                Forget password
              </a>
            </div>
            <Submit loading={submitting}>Submit</Submit>
            <div className={styles.other}>
              Another
              <AlipayCircleOutlined className={styles.icon} />
              <TaobaoCircleOutlined className={styles.icon} />
              <WeiboCircleOutlined className={styles.icon} />
              <Link className={styles.register} to="/user/register">
                Register account
              </Link>
            </div>
          </LoginFrom>
        </div>
      </div>
    </div>
  )
}

export default Login
