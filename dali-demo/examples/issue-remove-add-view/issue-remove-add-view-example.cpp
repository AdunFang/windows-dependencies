/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd.
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

/**
 * @file simple-text-editor-example.cpp
 * @brief Very basic usage of TextEditor control
 */

// EXTERNAL INCLUDES
#include <dali-toolkit/dali-toolkit.h>
#include <dali-toolkit/devel-api/controls/buttons/button-devel.h>
#include <sstream>

// INTERNAL INCLUDES
#include "shared/view.h"

using namespace Dali;
using namespace Dali::Toolkit;

/**
 * @brief The main class of the demo.
 */
class TextEditorExample : public ConnectionTracker
{
public:
  TextEditorExample( Application& application )
  : mApplication( application )
  {
    // Connect to the Application's Init signal
    mApplication.InitSignal().Connect( this, &TextEditorExample::Create );
  }

  ~TextEditorExample()
  {
    // Nothing to do here.
  }

  /**
   * One-time setup in response to Application InitSignal.
   */
  void Create( Application& application )
  {
    Stage stage = Stage::GetCurrent();
    stage.SetBackgroundColor( Color::WHITE );

    textLabel = TextLabel::New( "123" );
    textLabel.SetPosition( 0, 50, 0 );
    textLabel.SetAnchorPoint( AnchorPoint::TOP_LEFT );
    textLabel.SetName( "helloWorldLabel" );
    // stage.Add( textLabel );

    control = Control::New();
    control.SetName( "Control" );
    control.SetBackgroundColor( Color::CYAN );
    control.SetParentOrigin( ParentOrigin::CENTER );
    control.SetAnchorPoint( AnchorPoint::CENTER );
    control.SetSize( stage.GetSize().x, stage.GetSize().y, 0.0f );
    control.Add( textLabel );

    stage.Add( control );

    textLabel01 = TextLabel::New( "1" );
    textLabel01.SetPosition( 0, 50, 0 );
    textLabel01.SetAnchorPoint( AnchorPoint::TOP_LEFT );
    textLabel01.SetName( "newWorldLabel" );
    textLabel01.SetProperty( TextLabel::Property::POINT_SIZE, 10 );

    stage.KeyEventSignal().Connect(this, &TextEditorExample::OnKeyEvent);
  }

  void OnKeyEvent( const KeyEvent& event )
  {
    if( event.state == KeyEvent::Down )
    {
      if( IsKey( event, Dali::DALI_KEY_ESCAPE ) || IsKey( event, Dali::DALI_KEY_BACK ) )
      {
        // Exit application when click back or escape.
        mApplication.Quit();
      }
    }
    else if( event.state == KeyEvent::Up )
    {
      control.Remove( textLabel );
      control.Add( textLabel01 );
    }
  }

private:

  Application& mApplication;

  Control control;
  TextLabel textLabel;
  TextLabel textLabel01;
};

int DALI_EXPORT_API main( int argc, char **argv )
{
  // DALI_DEMO_THEME_PATH not passed to Application so TextEditor example uses default Toolkit style sheet.
  Application application = Application::New( &argc, &argv );
  TextEditorExample test( application );
  application.MainLoop();
  return 0;
}
