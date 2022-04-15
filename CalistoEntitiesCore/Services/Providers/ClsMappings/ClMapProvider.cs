using System.Reflection;

using CalistoStandards.Definitions;

namespace CalistoEnvironment.Services.Providers.ClsMappings;

public sealed class ClMapProvider : IDisposable
{
    private readonly DynamicProvider? _provider;

    public ClMapProvider() => _provider = new DynamicProvider();

    public async Task InitializeMaps() => await Task.Run(() => _provider?.InitializeMaps());
    public string SeekForSign<TSign>(TSign sign, bool tryTranslate = false) where TSign : struct, Enum
    {
        foreach (var (_, value) in _provider!)
        {
            if (!value.ContainsKey(sign)) continue;

            string mappedSign = value[sign];

            if (tryTranslate)
                TryTranslate(sign, ref mappedSign);

            return mappedSign;
        }

        return string.Empty;
    }


    private static void TryTranslate<TSign>(in TSign sign, ref string mappedSign)
    {
        mappedSign = sign switch
        {
            ClStatus ssign => ssign.Translate(),
            ClResult rsign => rsign.Translate(),
            _ => mappedSign
        };
    }

    public string GetMappedSign<TSign>(SignMapType mapType, TSign sign, bool tryTranslate = false) where TSign : struct, Enum
    {
        if (!_provider!.ContainsKey(mapType)) return null!;

        Dictionary<object, string> map = _provider?[mapType]!;
        if (map.Count == 0 || !map.ContainsKey(sign)) return null!;

        string mappedSign = map[sign];

        if (tryTranslate)
            TryTranslate(sign, ref mappedSign);

        return mappedSign;



    }

    public void InitMap(SignMapType mapSign)
    {
        if (_provider!.ContainsKey(mapSign))
            DisposeMap(mapSign);

        _provider!.SignsCount += 1;
        _provider!.EnsureCapacity(_provider.SignsCount);

        _provider.InitializeMap(mapSign);
    }
    public void DisposeMap(SignMapType mapType)
    {
        if (!_provider!.ContainsKey(mapType)) return;

        Dictionary<object, string> map = _provider?[mapType]!;

        map.Clear();
        map.EnsureCapacity(0);

        _provider!.Remove(mapType);

        _provider.TrimExcess();
        _provider.EnsureCapacity(_provider.SignsCount);
    }

    public IEnumerable<string> EnumerateMappedSigns<TSign>(SignMapType mapType, params TSign[] signs) where TSign : struct, Enum
        => from sign in signs select GetMappedSign(mapType, sign);
    public IEnumerable<string> EnumerateMappedSigns(SignMapType mapType)
        => from map in _provider![mapType] select map.Value;


    public void Dispose()
    {
        foreach (var map in _provider!)
            DisposeMap(map.Key);

        _provider.Clear();

        _provider.TrimExcess();
        _provider.EnsureCapacity(0);
    }



    private sealed class DynamicProvider : Dictionary<SignMapType, Dictionary<object, string>>
    {
        private readonly IEnumerable<TypeInfo>? _singsTypeInfo;

        internal int SignsCount;

        internal DynamicProvider()
        {
            var assemblyTypeRef = typeof(ClConsts);

            Assembly signsMapsAssembly = Assembly.GetAssembly(assemblyTypeRef!)!;

            _singsTypeInfo = signsMapsAssembly.DefinedTypes.
                Where(t => Attribute.IsDefined(t, typeof(SignMapAttr)));

            _singsTypeInfo.TryGetNonEnumeratedCount(out SignsCount);
        }

        public void InitializeMap(SignMapType mapSign)
        {
            TypeInfo? tinfo = _singsTypeInfo!.SingleOrDefault(s =>
                s.GetCustomAttribute<SignMapAttr>()?.MapSignType == mapSign);

            SignMapAttr? attr = tinfo?.GetCustomAttribute<SignMapAttr>();

            if (attr is null) return;

            InitializeMapByAttribute(in attr);
        }
        public void InitializeMaps()
        {
            foreach (TypeInfo tinfo in _singsTypeInfo!)
            {
                foreach (SignMapAttr attr in tinfo.GetCustomAttributes<SignMapAttr>())
                    InitializeMapByAttribute(in attr);
            }

            EnsureCapacity(SignsCount);
            //TrimExcess(SignsCount);
        }

        private void InitializeMapByAttribute(in SignMapAttr? attr)
        {
            SignMapType sMapType = attr!.MapSignType;
            Type mapType = attr.MapType;

            Array values = Enum.GetValues(mapType);
            string[] names = Enum.GetNames(mapType);

            int length = values.Length;

            Dictionary<object, string> map = new Dictionary<object, string>(length - 1);

            SetupMap(ref map, in length, in names, in values);

            Add(sMapType, map);
        }
        private static void SetupMap(ref Dictionary<object, string> map, in int length, in string[] names, in Array values)
        {
            for (int i = 1; i < length; i++)
            {
                string enumName = names[i];
                object enumValue = values.GetValue(i)!;
                Type enumValueType = enumValue.GetType();

                object mapKey = Enum.Parse(enumValueType, enumName);

                map.Add(mapKey, enumName);
            }

            map.EnsureCapacity(length);
            map.TrimExcess(length);
        }
    }
}
