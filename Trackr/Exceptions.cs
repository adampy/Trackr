using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackr {
    public class HttpStatusNotFound : Exception {
        public HttpStatusNotFound() {
        }
    }
    public class HttpStatusUnauthorized : Exception {
        public HttpStatusUnauthorized() {
        }
    }
}
