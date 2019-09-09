(function () {

    /**
     * queryString 转对象
     * @param {any} url
     */
    function parseQueryString(url) {
        var obj = {};
        var keyvalue = [];
        var key = "", value = "";
        var paraString = url.substring(url.indexOf("?") + 1, url.length).split("&");
        for (var i in paraString) {
            keyvalue = paraString[i].split("=");
            key = keyvalue[0];
            value = keyvalue[1];
            obj[key] = value;
        }
        return obj;
    }

    /* add custom header*/
    var CustomHeaders = function (name) {
        this.name = name;
    };

    CustomHeaders.prototype.apply = function (obj, authorizations) {
        console.log(obj);
        var requestParameterString = "";
        switch (obj.method) {
            case "GET":
                requestParameterString = JSON.stringify(parseQueryString(decodeURIComponent(obj.url)));
            break;
            default:
                requestParameterString = obj.body;
                break;
        }
        var appKey = "9zk6ZMQMSUYq16xqxYP8cQ=="; 
        var authToken = swaggerUi.api.clientAuthorizations.authz.bearerAuth ? swaggerUi.api.clientAuthorizations.authz.bearerAuth.value : "";
        var timestamp = Date.parse(new Date()) / 1000;
        var hash = md5(requestParameterString + appKey + timestamp + authToken).toUpperCase();//转大写
        obj.headers["Timestamp"] = timestamp;
        obj.headers["Sign"] = hash;
        return true;
    };

    swaggerUi.api.clientAuthorizations.add("CustomHeaders", new CustomHeaders("CustomHeaders"));
})();
