export class HttpClient {
    static get(url, loadCallback, errorCallback, context) {
        const request = new XMLHttpRequest();
        request.open("get", url, true);
        HttpClient.setProperty(request, loadCallback, errorCallback, context);
        request.send(null);
    }
    static postJson(url, data, callback, errorCallback, context) {
        const request = new XMLHttpRequest();
        request.open("post", url, true);
        HttpClient.setProperty(request, callback, errorCallback, context);
        request.setRequestHeader("Content-Type", "application/json; charset=utf-8");
        const json = JSON.stringify(data);
        request.send(json);
    }
    static postForm(url, formData, callback, errorCallback, progressCallback, context) {
        const request = new XMLHttpRequest();
        request.open("post", url, true);
        HttpClient.setProperty(request, callback, errorCallback, context);
        if (progressCallback != null) {
            request.upload.addEventListener("progress", progressCallback);
        }
        request.send(formData);
    }
    static setProperty(request, callback, errorCallback, context) {
        const csrfToken = HttpClient.getCsrfToken();
        if (csrfToken != "") {
            request.setRequestHeader("CsrfToken", csrfToken);
        }
        request.onload = function (event) {
            if (callback == null) {
                return;
            }
            if (request.status < 400) {
                callback(new HttpResponse(request), context);
            }
            else {
                if (errorCallback == null) {
                    if (HttpClient.errorCallback != null) {
                        HttpClient.errorCallback(new HttpResponse(request), context);
                    }
                    return;
                }
                errorCallback(new HttpResponse(request), context);
            }
        };
        request.onerror = function (event) {
            if (errorCallback == null) {
                if (HttpClient.errorCallback != null) {
                    HttpClient.errorCallback(new HttpResponse(request), context);
                }
                return;
            }
            errorCallback(new HttpResponse(request), context);
        };
    }
    static getCsrfToken() {
        if (document.getElementById("CsrfToken") != null) {
            return document.getElementById("CsrfToken").getAttribute("value");
        }
        return "";
    }
}
export class HttpResponse {
    constructor(request) {
        this.xmlHttpRequest = request;
        this.status = request.status;
        this.responseText = request.responseText;
    }
    jsonParse() {
        return JSON.parse(this.responseText);
    }
}
//# sourceMappingURL=HttpClient.js.map