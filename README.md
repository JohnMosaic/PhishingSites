# PhishingSites
Generate phishing domains from a custom dictionary. &lt;fake domains or sites>

Dictionary<char, List<char>> dict = new Dictionary<char, List<char>>()
{
    //Custom the dictionary by yourself...
    { '1', new List<char>() { '1', 'l', 'I' } },
    { 'l', new List<char>() { 'l', '1' } },

    { '2', new List<char>() { '2', 'Z' } },
    { 'z', new List<char>() { 'z', '2' } },

    { '4', new List<char>() { '4', 'f' } },
    { 'f', new List<char>() { 'f', '4' } },

    { '5', new List<char>() { '5', 'S' } },
    { 's', new List<char>() { 's', '5' } },

    { '6', new List<char>() { '6', 'b', 'G' } },
    { 'b', new List<char>() { 'b', '6' } },

    { '7', new List<char>() { '7', 'T' } },

    { '8', new List<char>() { '8', 'B', 'R' } },

    { '9', new List<char>() { '9', 'g' } },
    { 'g', new List<char>() { 'g', '9' } },

    { '0', new List<char>() { '0', 'D', 'O', 'Q' } },
    { 'o', new List<char>() { 'o', '0', 'Q' } }
};
