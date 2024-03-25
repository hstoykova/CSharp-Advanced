namespace Television.Tests
{
    using System;
    using System.Diagnostics;
    using NUnit.Framework;
    public class Tests
    {
        private TelevisionDevice device;

        [SetUp]
        public void Setup()
        {
            string brand = "Samsung";
            double price = 199.99;
            int screenWidth = 20;
            int screenHeigth = 15;
            device = new(brand, price, screenWidth, screenHeigth);
        }

        [Test]
        public void ConstructorCheck()
        {
            string brand = "Samsung";
            double price = 199.99;
            int screenWidth = 20;
            int screenHeigth = 15;

            Assert.AreEqual(brand, device.Brand);
            Assert.AreEqual(price, device.Price);
            Assert.AreEqual(screenWidth, device.ScreenWidth);
            Assert.AreEqual(screenHeigth, device.ScreenHeigth);
        }

        [Test]
        public void SwitchOnCheckOn()
        {
            int currentChannel = 5;
            device.ChangeChannel(currentChannel);
            int volume = 10;
            string direction = "DOWN";
            device.VolumeChange(direction, 3);
            Assert.AreEqual($"Cahnnel {currentChannel} - Volume {volume} - Sound On", device.SwitchOn());

            device.MuteDevice();
            Assert.AreEqual($"Cahnnel {currentChannel} - Volume {volume} - Sound Off", device.SwitchOn());
        }

        [Test]
        public void ChangeChannelThrowsErrorIfChanelIsInvalid()
        {
            int currentChannel = -5;

            var ex = Assert.Throws<ArgumentException>(() =>
            {
                device.ChangeChannel(currentChannel);
            }
            );

            Assert.AreEqual("Invalid key!", ex.Message);
        }

        [Test]
        public void ChangeChannelWorksCorrectly()
        {
            int channel = 3;
            var changed = device.ChangeChannel(channel);

            Assert.AreEqual(channel, device.CurrentChannel);

            Assert.AreEqual(channel, changed);
        }

        [Test]
        public void VolumeChangeGreaterThan100()
        {
            string direction = "UP";
            device.VolumeChange(direction, 90);

            Assert.AreEqual(100, device.Volume);
        }

        [Test]
        public void VolumeChangeLeeThan0()
        {
            string direction = "DOWN";
            device.VolumeChange(direction, 20);

            Assert.AreEqual(0, device.Volume);
        }

        [Test]
        public void VolumeChangeStringOutput()
        {
            string direction = "DOWN";
            var output = device.VolumeChange(direction, 3);

            Assert.AreEqual("Volume: 10", output);
        }

        [Test]
        public void MuteDeviceTest()
        {
            Assert.AreEqual(false, device.IsMuted);

            device.MuteDevice();

            Assert.AreEqual(true, device.IsMuted);
        }

        [Test]
        public void ToStringResultTest()
        {
            string brand = "Samsung";
            double price = 199.99;
            int screenWidth = 20;
            int screenHeigth = 15;
            
            string result = device.ToString();
            StringAssert.Contains($"TV Device: {brand}", result);
            StringAssert.Contains($"Screen Resolution: {screenWidth}x{screenHeigth}", result);
            StringAssert.Contains($"Price {price}", result);
        }
    }
}
