namespace SmartDevice.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorCheck()
        {
            int memory = 50;
            Device device = new Device(memory);
            Assert.AreEqual(memory, device.AvailableMemory);
            Assert.AreEqual(memory, device.MemoryCapacity);
            Assert.AreEqual(0, device.Photos);
            Assert.AreEqual(0, device.Applications.Count);
        }

        [Test]
        public void TakePhotoSizeWorkCorrectly()
        {
            int photoSize = 10;
            int memory = 50;
            Device device = new Device(memory);
            bool result = device.TakePhoto(photoSize);
            Assert.IsTrue(result);
            Assert.AreEqual(memory - photoSize, device.AvailableMemory);
            Assert.AreEqual(1, device.Photos);
        }

        [Test]
        public void TakePhotoSizeReturnsFalseWhenNotEnoughMemory()
        {
            int photoSize = 10;
            int memory = 5;
            Device device = new Device(memory);
            bool result = device.TakePhoto(photoSize);
            Assert.IsFalse(result);

            Assert.AreEqual(memory, device.AvailableMemory);
            Assert.AreEqual(0, device.Photos);
        }

        [Test]
        public void InstallAppWorksCorrectly()
        {
            int appSize = 10;
            int memory = 50;
            string appName = "Picture";
            Device device = new Device(memory);
            string result = device.InstallApp(appName, appSize);
            Assert.AreEqual(memory - appSize, device.AvailableMemory);
            Assert.AreEqual(appName, device.Applications.First());
            Assert.IsTrue(result.StartsWith(appName));
        }

        [Test]
        public void InstallAppThrowsErrorWhenNotEnoughMemory()
        {
            int appSize = 20;
            int memory = 10;
            string appName = "Picture";
            Device device = new Device(memory);

            var ex = Assert.Throws<InvalidOperationException>(()=>
                {
                    device.InstallApp(appName, appSize);               
                }
            );

            Assert.AreEqual("Not enough available memory to install the app.", ex.Message);
        }

        [Test]
        public void FormatDeviceCheck()
        {
            int appSize = 20;
            int memory = 30;
            int photoSize = 5;
            string appName = "Picture";
            Device device = new Device(memory);
            device.InstallApp(appName, appSize);
            device.TakePhoto(photoSize);
            device.FormatDevice();
            Assert.AreEqual(0, device.Photos);
            Assert.AreEqual(0, device.Applications.Count);
            Assert.AreEqual(memory, device.AvailableMemory);
        }

        [Test]
        public void GetDeviceStatusWorksCorrectly()
        {
            int appSize = 20;
            int memory = 30;
            int photoSize = 5;
            string appName = "Picture";
            Device device = new Device(memory);
            device.InstallApp(appName, appSize);
            device.TakePhoto(photoSize);
            string result = device.GetDeviceStatus();
            StringAssert.Contains($"Memory Capacity: {memory} MB", result);
            StringAssert.Contains($"Available Memory: {device.AvailableMemory} MB", result);
            StringAssert.Contains($"Photos Count: {device.Photos}", result);
            StringAssert.Contains($"Applications Installed: {appName}", result);
        }
    }
}