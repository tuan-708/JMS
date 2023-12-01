export function showSuccess(toastr: any, message:any) {
    toastr.success(message, 'Thành công', {
        progressBar: true,
        timeOut: 3000,
        enableHtml: true
    });
}

export function showInfo(toastr: any, message: any) {
    toastr.info(message, 'Thành công', {
        progressBar: true,
        timeOut: 3000,
        enableHtml: true
    });
}

export function showError(toastr: any, message: any) {
    toastr.error(message, 'Lỗi', {
        progressBar: true,
        timeOut: 3000,
        enableHtml: true
    });
}