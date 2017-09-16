export default function (error) {
  let message
  if (error) {
    if (error.response) {
      message = error.response.data && typeof error.response.data === 'string' && error.response.data || error.response.data.message
    }
    else if (error.message) {
      message = error.message
    }
    else if (typeof error === 'string') {
      message = error
    }
  }
  if (!message) {
    message = 'Ocurrió un error desconocido.'
  }
  alert(message)
}
