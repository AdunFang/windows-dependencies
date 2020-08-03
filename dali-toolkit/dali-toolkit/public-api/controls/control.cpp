/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

// CLASS HEADER
#include <dali-toolkit/public-api/controls/control.h>

// EXTERNAL INCLUDES
#include <dali/integration-api/debug.h>

// INTERNAL INCLUDES
#include <dali-toolkit/public-api/controls/control-impl.h>
#include <dali-toolkit/internal/controls/control/control-data-impl.h>

namespace Dali
{

namespace Toolkit
{

Control Control::New()
{
  return Internal::Control::New();
}

Control::Control()
{
}

Control::Control( const Control& uiControl )
: CustomActor( uiControl  )
{
}

Control::~Control()
{
}

Control& Control::operator=( const Control& handle )
{
  if( &handle != this )
  {
    CustomActor::operator=( handle );
  }
  return *this;
}

Control Control::DownCast( BaseHandle handle )
{
  return DownCast< Control, Internal::Control >(handle);
}

void Control::SetKeyInputFocus()
{
  Internal::GetImplementation(*this).SetKeyInputFocus();
}

bool Control::HasKeyInputFocus()
{
  return Internal::GetImplementation(*this).HasKeyInputFocus();
}

void Control::ClearKeyInputFocus()
{
  Internal::GetImplementation(*this).ClearKeyInputFocus();
}

PinchGestureDetector Control::GetPinchGestureDetector() const
{
  return Internal::GetImplementation(*this).GetPinchGestureDetector();
}

PanGestureDetector Control::GetPanGestureDetector() const
{
  return Internal::GetImplementation(*this).GetPanGestureDetector();
}

TapGestureDetector Control::GetTapGestureDetector() const
{
  return Internal::GetImplementation(*this).GetTapGestureDetector();
}

LongPressGestureDetector Control::GetLongPressGestureDetector() const
{
  return Internal::GetImplementation(*this).GetLongPressGestureDetector();
}

void Control::SetStyleName( const std::string& styleName )
{
  Internal::GetImplementation(*this).SetStyleName( styleName );
}

const std::string& Control::GetStyleName() const
{
  return Internal::GetImplementation(*this).GetStyleName();
}

void Control::SetBackgroundColor( const Vector4& color )
{
  Internal::GetImplementation(*this).SetBackgroundColor( color );
}

void Control::ClearBackground()
{
  Internal::GetImplementation(*this).ClearBackground();
}

bool Control::IsResourceReady() const
{
  const Internal::Control& internalControl = Toolkit::Internal::GetImplementation( *this );
  const Internal::Control::Impl& controlDataImpl = Internal::Control::Impl::Get( internalControl );

  return controlDataImpl.IsResourceReady();
}

Toolkit::Visual::ResourceStatus Control::GetVisualResourceStatus( Dali::Property::Index index )
{
  const Internal::Control& internalControl = Toolkit::Internal::GetImplementation( *this );
  const Internal::Control::Impl& controlDataImpl = Internal::Control::Impl::Get( internalControl );
  return controlDataImpl.GetVisualResourceStatus( index );
}

Control::KeyEventSignalType& Control::KeyEventSignal()
{
  return Internal::GetImplementation(*this).KeyEventSignal();
}

Control::KeyInputFocusSignalType& Control::KeyInputFocusGainedSignal()
{
  return Internal::GetImplementation(*this).KeyInputFocusGainedSignal();
}

Control::KeyInputFocusSignalType& Control::KeyInputFocusLostSignal()
{
  return Internal::GetImplementation(*this).KeyInputFocusLostSignal();
}

Control::ResourceReadySignalType&  Control::ResourceReadySignal()
{
  Internal::Control& internalControl = Toolkit::Internal::GetImplementation( *this );
  Internal::Control::Impl& controlImpl = Internal::Control::Impl::Get( internalControl );

  return controlImpl.mResourceReadySignal;
}

Control::Control(Internal::Control& implementation)
: CustomActor(implementation)
{
}

Control::Control(Dali::Internal::CustomActor* internal)
: CustomActor(internal)
{
  VerifyCustomActorPointer<Internal::Control>(internal);
}

} // namespace Toolkit

} // namespace Dali
