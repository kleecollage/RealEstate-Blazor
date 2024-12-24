window.ShowToastr = (type, message) => {
    if (type === 'success') {
        toastr.success(message, "Operation Success!", { timeout: 3000});
    }
    if (type === 'error') {
        toastr.error(message, "Operation Failed.", { timeout: 3000});
    }
}

window.ShowSwal = (type, message) => {
    if (type === 'success') {
        Swal.fire(
            'Success Notification!',
            message,
            'success'
        )
    }
    if (type === 'error') {
        Swal.fire(
            'Error Notification.',
            message,
            'error'
        )
    }
}

function showModalOnConfirmDeleted() {
    $('#modalOnConfirmDelete').modal('show');
}

function hideModalOnConfirmDeleted() {
    $('#modalOnConfirmDelete').modal('hide');
}












