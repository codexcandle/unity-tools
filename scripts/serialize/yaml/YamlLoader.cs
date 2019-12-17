// SOURCE: http://www.samuraifight.com/2015/09/17/yaml-quickstart/
// DESCRIPTION: Example class to use as model for YAML parser.

using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;
/// using YamlDotNet.Serialization;
/// using YamlDotNet.Serialization.NamingConventions;

public class YamlLoader : MonoBehaviour {

    /*
     TODO - uncomment below AFTER including YAML-DOT-NET package!
    // Use this for initialization
    void Start ()
    {
        // read the file
        String yamlText = File.ReadAllText("Assets/example.yaml");
        TextReader input = new StringReader(yamlText);

        // get the yaml
        Deserializer deserializer = new Deserializer(namingConvention: 
                                            new CamelCaseNamingConvention());

        // make the yaml into our test object
        YamlObject test = deserializer.Deserialize(input);
    }

    public class YamlObject
    {
        public string Receipt { get; set; }
        public DateTime Date { get; set; }
        public List Items { get; set; }
    }

    public class OrderItem
    {
        public string Part { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
    */
}