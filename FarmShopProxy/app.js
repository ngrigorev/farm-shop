const httpProxy = require('http-proxy');
const proxyPort = 1010;
const targetURL = 'http://localhost:5000';

httpProxy
  .createProxyServer({ target:targetURL })
  .listen(proxyPort);