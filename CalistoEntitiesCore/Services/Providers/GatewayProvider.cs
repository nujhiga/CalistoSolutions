﻿using CalistoEnvironment.ClSecurity;

using CalistoStandars.Definitions.Enumerations;
using CalistoStandars.Definitions.Structures;

namespace CalistoEnvironment.Services.Providers;

//todo: implement idisposable interface :: tdref:230322-1
public sealed class GatewayProvider : IDisposable
{

    private readonly Dictionary<int, string[]> _wAccessData;
    private string[] _lAccessData { get; set; }

    private string _key;
    public string Key
    {
        get => Security.HexToString(_key);
        set => _key = value;
    }

    public GatewayProvider() => _wAccessData = new Dictionary<int, string[]>();

    private bool _disposed;

    private CampusTarget _currentCampus;
    public CampusTarget CurrentCampus
    {
        get => _currentCampus;
        set
        {
            _currentCampus = value;
            ClEnvironment.Instance.SetClientCredentials(value);
        }
    }

    public CampusTarget CreateNewTarget(ClCampus source) => new CampusTarget(source, GetSpAddress(source));
        
    #region Access & Address
    private string GetAccess(in int index, in int aindex) => _wAccessData.Count == 0 ? null! : Security.Decrypt(Key, _wAccessData[index][aindex]);
    private string GetAddress(in int index) => _wAccessData.Count == 0 ? null! : Security.Decrypt(Key, _wAccessData[index][0]);
    private string GetSoapAddress(in int index)
    {
        string address = GetAddress(in index);
        return address is null ? null! : $"https://{address}/soap/";
    }
    private string GetUrlAddress(in int index)
    {
        string address = GetAddress(in index);
        return address is null ? null! : $"https://{address}";
    }
    private string GetUsAccess(int index) => GetAccess(in index, 1);
    private string GetPwAccess(int index) => GetAccess(in index, 2);
    private string GetPwCampusAccess(int index) => GetAccess(in index, 3);
    public string GetCmpUsAccess() => "webmaster"; // todo: implement safe access :: tdref:230322-5
    public string GetCmpPwAccess(ClCampus cSource) => GetPwCampusAccess((int)cSource);
    public string GetPwAccess(ClCampus cSource) => "ZndNaApxDt"; //GetPwAccess((int)cSource);
    public string GetPwAccess() => "ZndNaApxDt"; //GetPwAccess(CurrentCampus.Source);
    public string GetUsAccess(ClCampus cSource) => "webservice"; //GetUsAccess((int)cSource);
    public string GetUsAccess() => "webservice"; //GetUsAccess(CurrentCampus.Source) 
    public string Address(ClCampus cSource) => GetAddress((int)cSource);
    public string GetSpAddress(ClCampus? cSource) => "https://campus.untrefvirtual.edu.ar/soap/"; //GetSoapAddress((int)cSource);


    #endregion

    #region IDisposable Pattern


    private void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                // TODO: dispose managed state (managed objects)
            }

            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
            // TODO: set large fields to null
            _disposed = true;
        }
    }

    // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
    ~GatewayProvider()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method

        Dispose(disposing: false);
    }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    #endregion
}
