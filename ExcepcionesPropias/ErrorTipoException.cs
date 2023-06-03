namespace ExcepcionesPropias
{
    public class ErrorTipoException : Exception
    {

        public ErrorTipoException () { }
                
        public ErrorTipoException (string msg) : base (msg) { }

        public ErrorTipoException(string msg, Exception inner) : base (msg, inner) { }
       
    }
}