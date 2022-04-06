const createProxyMiddleware = require('http-proxy-middleware');
const {env} = require('process');

const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
    env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'http://localhost:39838';

const context = [
    "/weatherforecast",
    "/api/landsatawsdataset",
    "/api/landsatcatalogbuilder",
    "/api/landsattilegenerator",
    "/landsat-tile",
    "/api/weather",
    "/api/news",
    "/api/account"
];

module.exports = function (app) {
    const appProxy = createProxyMiddleware(context, {
        target: target,
        secure: false
    });

    app.use(appProxy);
};
