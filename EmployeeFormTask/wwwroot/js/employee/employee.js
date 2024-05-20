

        $(document).ready(function () {
            $('#employeeForm').on('submit', function (event) {
                event.preventDefault();

                $.ajax({
                    type: 'POST',
                    url: $(this).attr('action'),
                    data: $(this).serialize(),
                    success: function (response) {
                        if (response.success) {
                            Swal.fire({
                                icon: 'success',
                                title: 'Employee Added',
                                text: 'The employee has been added successfully!',
                                timer: 2000,
                                showConfirmButton: false
                            }).then(function () {
                                window.location.href = redirectToIndexUrl;
                            });
                        } else {
                            $('#employeeForm').html(response);
                        }
                    },
                    error: function () {
                        Swal.fire({
                            icon: 'error',
                            title: 'Error',
                            text: 'An error occurred while processing your request.',
                        });
                    }
                });
            });
        });
