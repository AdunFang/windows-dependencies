#include "CustomFile.h"

extern void* MemFOpen( uint8_t* buffer, size_t dataSize, const char * const mode );
extern void MemFClose( const void *fp );
extern int MemFRead( void* buf, int eleSize, int count, const void *fp );
extern void MemFWrite( void *buf, int size, const void *fp );
extern int MemFSeek( const void *fp, int offset, int origin );
extern int MemFTell( const void *fp );
extern bool MemFEof( const void *fp );

extern void* OriginalFOpen( const char *name, const char *mode );
extern int OriginalFClose( const void *fp );
extern int OriginalFRead( void* buf, int eleSize, int count, const void *fp );
extern void OriginalFWrite( void *buf, int size, const void *fp );
extern int OriginalFSeek( const void *fp, int offset, int origin );
extern int OriginalFTell( const void *fp );
extern bool OriginalFEof( const void *fp );

namespace CustomFile
{
void* FOpen( const char *name, const char *mode )
{
  return (void*)OriginalFOpen( name, mode );
}

int FClose( const void* fp )
{
  if( -1 == *( (char*)fp + 4 ) )
  {
    MemFClose( fp );
    return 0;
  }
  else
  {
    return OriginalFClose( fp );
  }
}

void* FMemopen( void* buffer, size_t dataSize, const char * const mode )
{
  return (void*)MemFOpen( ( uint8_t*)buffer, dataSize, mode );
}

int FRead( void* buf, int eleSize, int count, const void *fp )
{
  if( -1 == *( (char*)fp + 4 ) )
  {
    return MemFRead( buf, eleSize, count, fp );
  }
  else
  {
    return OriginalFRead( buf, eleSize, count, fp );
  }
}

void FWrite( void *buf, int size, const void *fp )
{
  if( -1 == *( (char*)fp + 4 ) )
  {
    MemFWrite( buf, size, fp );
  }
  else
  {
    OriginalFWrite( buf, size, fp );
  }
}

int FSeek( const void *fp, int offset, int origin )
{
  if( -1 == *( (char*)fp + 4 ) )
  {
    return MemFSeek( fp, offset, origin );
  }
  else
  {
    return OriginalFSeek( fp, offset, origin );
  }
}

int FTell( const void *fp )
{
  if( -1 == *( (char*)fp + 4 ) )
  {
    return MemFTell( fp );
  }
  else
  {
    return OriginalFTell( fp );
  }
}

bool FEof( const void *fp )
{
  if( -1 == *( (char*)fp + 4 ) )
  {
    return MemFEof( fp );
  }
  else
  {
    return OriginalFEof( fp );
  }
}
}

extern "C"
{
size_t __cdecl fread_for_c( void*  _Buffer, size_t _ElementSize, size_t _ElementCount, void*  _Stream )
{
  return CustomFile::FRead( _Buffer, _ElementSize, _ElementCount, _Stream );
}

void __cdecl fwrite_for_c( void *buf, int size, const void *fp )
{
  CustomFile::FWrite( buf, size, fp );
}
}