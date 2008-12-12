package com.thoughtworks.selenium.samples;

import com.thoughtworks.selenium.DefaultSelenium;
import com.thoughtworks.selenium.Selenium;
import com.thoughtworks.selenium.Silvernium;

import junit.framework.TestCase;

public class TestMonotone extends TestCase {
        private Silvernium silverLightApp;
        private Selenium selenium;


        private final static String URL = "http://www.lutzroeder.com/silverlight/Monotone/Default.aspx";

        public void setUp() {
                selenium = new DefaultSelenium("localhost", 4444, "*iexplore", URL);
                selenium.start();
                silverLightApp = new Silvernium(selenium, "ID");
                selenium.open(URL);
        }

        public void tearDown() {
                selenium.stop();
        }

        public void testDefaultProperties() {
                assertEquals("Monotone", selenium.getTitle());
                assertEquals(600, silverLightApp.actualWidth());
                assertEquals(400, silverLightApp.actualHeight());
        }




}

