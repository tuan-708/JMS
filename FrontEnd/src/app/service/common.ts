export function showSuccess(toastr: any, message: any) {
   toastr.success(message, 'Thành công', {
      progressBar: true,
      timeOut: 1500,
      enableHtml: true
   });
}

export function showInfo(toastr: any, message: any) {
   toastr.info(message, 'Thông báo', {
      progressBar: true,
      timeOut: 1500,
      enableHtml: true
   });
}

export function showError(toastr: any, message: any) {
   toastr.error(message, 'Lỗi', {
      progressBar: true,
      timeOut: 1500,
      enableHtml: true
   });
}