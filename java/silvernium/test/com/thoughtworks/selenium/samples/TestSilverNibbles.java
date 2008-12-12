package com.thoughtworks.selenium.samples;

import com.thoughtworks.selenium.DefaultSelenium;
import com.thoughtworks.selenium.Selenium;
import com.thoughtworks.selenium.Silvernium;

import junit.framework.TestCase;

public class TestSilverNibbles extends TestCase {
    private Silvernium silverLightApp;
    private Selenium selenium;


    private final static String URL = "http://www.markheath.me.uk/silvernibbles/";

    public void setUp() {
            selenium = new DefaultSelenium("localhost", 4444, "*iexplore", URL);
            selenium.start();
            silverLightApp = new Silvernium(selenium, "SilverlightControl", "SilverNibbles");
            selenium.open(URL);
    }

    public void tearDown() {
            selenium.stop();
    }

    public void testCommunicationWithSilverLightObj() {
    		// verifies webpage title
            assertEquals("SilverNibbles", selenium.getTitle());
            // verifies default properties in the silverlight object
            assertEquals(640, silverLightApp.actualWidth());
            assertEquals(460, silverLightApp.actualHeight());

            // verifies user defined properties and methods
            // content.SilverNibbles.StartingSpeed;,  returns 5
            assertEquals("5", silverLightApp.getPropertyValue("StartingSpeed"));
            // content.SilverNibbles.NewGame('1');,  returns null
            assertEquals("null", silverLightApp.call("NewGame", "1"));

            
            // testing set and get for a user defined property
            assertEquals("5", silverLightApp.getPropertyValue("StartingSpeed"));
            // setting the property
            silverLightApp.setPropertyValue("StartingSpeed", "8");
            // getting it again
            assertEquals("8", silverLightApp.getPropertyValue("StartingSpeed"));
            
    }



}
