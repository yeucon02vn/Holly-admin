const fabric = require('@umijs/fabric')

module.exports = {
  ...fabric.prettier,
  printWidth: 100,
  semi: false,
  singleQuote: true,
  trailingComma: 'all',
}
