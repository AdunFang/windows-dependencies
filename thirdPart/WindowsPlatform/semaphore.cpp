#include "semaphore.h"
#include <Win32WindowSystem.h>
#include <Windows.h>

void sem_init( sem_t *sem, int p1, int p2 )
{
  *sem = Win32WindowSystem::CreateWinSemaphore( 0, 1 );
}

void sem_post( sem_t *sem )
{
  Win32WindowSystem::ReleaseSemaphore( *sem, 1, 0 );
}

void sem_wait( sem_t *sem )
{
  Win32WindowSystem::WaitForSingleObject( *sem, INFINITE );
}

long sem_timedwait( sem_t *sem, timespec *time )
{
  long dwMilliseconds = time->tv_sec * 1000000 + time->tv_nsec / 1000;

  return Win32WindowSystem::WaitForSingleObject( *sem, dwMilliseconds );
}
