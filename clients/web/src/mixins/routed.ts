import axios from 'axios'

interface Options {
  dataURL?: string
}

export default function Routed (options: Options) {
  if (options.dataURL) {
    this.beforeRouteEnter = async function (to, from, next) {
      try {
        const { data } = await axios.get(options.dataURL!)
        next(vm => {
          vm.users = data
        })
      }
      catch (error) {
        next(error)
      }
    }
  }
}
