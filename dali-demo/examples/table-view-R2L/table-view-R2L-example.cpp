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

#include "shared/view.h"
#include <dali/dali.h>
#include <dali-toolkit/dali-toolkit.h>

using namespace Dali;

// Define this so that it is interchangeable
// "DP" stands for Device independent Pixels
#define DP(x) x


namespace
{

  const char* const BACKGROUND_IMAGE = DEMO_IMAGE_DIR "background-gradient.jpg";
  const char* const TOOLBAR_IMAGE = DEMO_IMAGE_DIR "top-bar.png";

  const char* const TOOLBAR_TITLE = "Buttons";

  const char* const SMALL_IMAGE_1 = DEMO_IMAGE_DIR "gallery-small-14.jpg";
  const char* const BIG_IMAGE_1 = DEMO_IMAGE_DIR "gallery-large-4.jpg";

  const char* const SMALL_IMAGE_2 = DEMO_IMAGE_DIR "gallery-small-20.jpg";
  const char* const BIG_IMAGE_2 = DEMO_IMAGE_DIR "gallery-large-11.jpg";

  const char* const SMALL_IMAGE_3 = DEMO_IMAGE_DIR "gallery-small-25.jpg";
  const char* const BIG_IMAGE_3 = DEMO_IMAGE_DIR "gallery-large-13.jpg";

  const char* const ENABLED_IMAGE = DEMO_IMAGE_DIR "item-select-check.png";

  const Vector4 BACKGROUND_COLOUR( 1.0f, 1.0f, 1.0f, 0.15f );

  // Layout sizes
  const int RADIO_LABEL_THUMBNAIL_SIZE = 60;
  const int RADIO_LABEL_THUMBNAIL_SIZE_SMALL = 40;
  const int RADIO_IMAGE_SPACING = 8;
  const int BUTTON_HEIGHT = 48;

  const int MARGIN_SIZE = 10;
  const int TOP_MARGIN = 85;
  const int GROUP2_HEIGHT = 238;
  const int GROUP1_HEIGHT = 120;
  const int GROUP3_HEIGHT = 190;
  const int GROUP4_HEIGHT = BUTTON_HEIGHT + MARGIN_SIZE * 2;

  const int contentRowCount = 3;
  const int contentColCount = 3;

}  // namespace

   /** This example shows how to create and use different buttons.
   *
   * 1. First group of radio buttons with image actor labels selects an image to load
   * 2. A push button loads the selected thumbnail image into the larger image pane
   * 3. Second group of radio buttons with a table view label containing a text view and image view, and a normal text view.
   *    Selecting one of these will enable/disable the image loading push button
   * 4. A group of check boxes
   */
class TableViewR2L : public ConnectionTracker
{
public:

  TableViewR2L( Application& application )
    : mApplication( application )
  {
    // Connect to the Application's Init signal
    mApplication.InitSignal().Connect( this, &TableViewR2L::Create );
  }

  ~TableViewR2L()
  {
    // Nothing to do here
  }

  void Create( Application& application )
  {
    // The Init signal is received once (only) during the Application lifetime

    // Respond to key events
    Stage::GetCurrent().KeyEventSignal().Connect( this, &TableViewR2L::OnKeyEvent );

    // Creates a default view with a default tool bar.
    // The view is added to the stage.
    mContentLayer = DemoHelper::CreateView( application,
      mView,
      mToolBar,
      BACKGROUND_IMAGE,
      TOOLBAR_IMAGE,
      TOOLBAR_TITLE );

    mBackGroundTable = Toolkit::TableView::New( 1, 1 );
    mBackGroundTable.SetResizePolicy( ResizePolicy::FILL_TO_PARENT, Dimension::WIDTH );
    mBackGroundTable.SetResizePolicy( ResizePolicy::USE_NATURAL_SIZE, Dimension::HEIGHT );
    mBackGroundTable.SetAnchorPoint( AnchorPoint::TOP_LEFT );
    mBackGroundTable.SetParentOrigin( ParentOrigin::TOP_LEFT );
    for( unsigned int i = 0; i < mBackGroundTable.GetRows(); ++i )
    {
      mBackGroundTable.SetFitHeight( i );
    }

    mBackGroundTable.SetPosition( 0.0f, TOP_MARGIN );

    mContentTable = Toolkit::TableView::New( contentRowCount, contentColCount );
    mContentTable.SetStyleName( "RealTable" );
    mContentTable.SetInheritOrientation( false );
    mContentTable.SetResizePolicy( ResizePolicy::FILL_TO_PARENT, Dimension::WIDTH );
    mContentTable.SetResizePolicy( ResizePolicy::USE_NATURAL_SIZE, Dimension::HEIGHT );
    mContentTable.SetAnchorPoint( AnchorPoint::TOP_LEFT );
    mContentTable.SetParentOrigin( ParentOrigin::TOP_LEFT );
    mContentTable.SetCellPadding( Size( MARGIN_SIZE, MARGIN_SIZE * 0.5f ) );

    for( unsigned int i = 0; i < mContentTable.GetRows(); ++i )
    {
      mContentTable.SetFitHeight( i );
    }

    mContentTable.SetPosition( 0.0f, TOP_MARGIN );

    mBackGroundTable.Add( mContentTable );

    int btnIndex = 0;

    for( size_t i = 0; i < contentRowCount; i++ )
    {
      for( size_t j = 0; j < contentColCount; j++ )
      {
        Toolkit::PushButton button = Toolkit::PushButton::New();
        std::string label = "Btn";
        label.push_back( '(' );
        label.push_back( btnIndex++ + '0' );
        label.push_back( ')' );

        button.SetProperty( Toolkit::Button::Property::LABEL, label );
        button.SetParentOrigin( ParentOrigin::TOP_CENTER );
        button.SetAnchorPoint( AnchorPoint::TOP_CENTER );
        //button.ClickedSignal().Connect(this, &ImageViewController::ToggleImageOnStage);
        button.SetResizePolicy( ResizePolicy::FILL_TO_PARENT, Dimension::WIDTH );
        //button.SetResizePolicy(ResizePolicy::USE_NATURAL_SIZE, Dimension::HEIGHT);
        std::string s = std::to_string( i * 4 + j );
        button.SetName( s );

        mContentTable.Add( button );
      }
    }

    mContentLayer.Add( mBackGroundTable );
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
      else
      {
        static int direction = 0;
        direction = !direction;
        mContentLayer.SetProperty( Dali::Actor::Property::LAYOUT_DIRECTION, direction );
      }
    }
  }

private:

  Application&      mApplication;
  Toolkit::Control  mView;                              ///< The View instance.
  Toolkit::ToolBar  mToolBar;                           ///< The View's Toolbar.
  Layer             mContentLayer;                      ///< Content layer

  Toolkit::TableView mBackGroundTable;
  Toolkit::TableView mContentTable;
};

void RunTest( Application& application )
{
  TableViewR2L test( application );

  application.MainLoop();
}

// Entry point for Linux & Tizen applications
//
#ifdef __GNUC__
int DALI_EXPORT_API main( int argc, char** argv )
#else
int DALI_EXPORT_API Table_View_R2L_Main( int argc, char** argv )
#endif
{
  Application application = Application::New( &argc, &argv, DEMO_THEME_PATH );

  RunTest( application );

  return 0;
}
