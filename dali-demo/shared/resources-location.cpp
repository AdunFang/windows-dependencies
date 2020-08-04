/**
 * This file defines the location dali-demo resources.
 * It is used for builds where an application resource directory is NOT explicity defined.
 */

#include <cstdlib>

int dali_demo_RESOURCE_DIR = setenv("DALI_APPLICATION_PACKAGE",  "/home/fangxh/originalDali/dali-env/opt/share/com.samsung.dali-demo/res" , 1);
