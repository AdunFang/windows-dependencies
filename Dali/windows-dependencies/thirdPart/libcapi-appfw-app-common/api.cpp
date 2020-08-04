#include <string>

typedef char * ( __stdcall* SWIG_CSharpStringHelperCallback )( const char * );
SWIG_CSharpStringHelperCallback CreateStringCallback = NULL;

#ifdef __cplusplus
extern "C"
#endif
__declspec( dllexport ) void __stdcall RegisterCreateStringCallback( SWIG_CSharpStringHelperCallback callback )
{
  CreateStringCallback = callback;
}

char* CreateString(const char *string)
{
  return CreateStringCallback( string );
}

__declspec( dllexport ) char* __stdcall app_get_resource_path()
{
  static std::string envValue = "";

  if( true == envValue.empty() )
  {
    envValue = std::getenv( "DemoRes" );
    envValue += "/";
  }

  char *ret = CreateString( envValue.c_str() );
  return ret;
}

__declspec( dllexport ) int __stdcall app_get_id(char **appID)
{
  *appID = CreateString("CurrentAPP");
  return 0;
}
